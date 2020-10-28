// ************************************************************************************************************
//************************************SSDQopenECA Analytic********************************
//Code for Hankel Robust Data Estimation of the Streaming Synchrophasor Data Quality and Conditioning application.
//Company- Electric Power Research Institute (EPRI)
//Manager- Dr. Evangelos Farantatos
//Algorithm & Code developed by-Rensselaer Polytechnic Institute
//Modified by- Jacob Libsman, Rensselaer Polytechnic Institute
//File:HankelProcessComplex.cs
//Description:This code segment implements the SSDQ algorithm using the current and past frame of measurements and the 
//parameters provided by the user.
//Inputs:Parameters from ParameterForm and Current_data from specified Input measurement channels metadata. 
//Output:Processed and conditioned data
//*************************************************************************************************************
using System;
using System.ComponentModel;
using System.Numerics;
using System.Linq;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Factorization;
using MathNet.Numerics.Statistics;
using SSDQopenECA;
using Error_Recovery;

namespace HankelRobustDataEstimation
{
    [Description("HankelRobustDataEstimation: robust data estimation with low-rank Hankel structure")]
    public class HankelProcessComplex
    {
        //keep the past L estimated data and observed data
        private Matrix<Complex> data_estimate;         // contain the past L estimations
        private Matrix<Complex> data_observed;         // contains the past L raw observations        
        private Matrix<double> flag_trusted;          // denote whether each entry is trusted
        private Matrix<double> flag_observed;         // denote whether each entry is observed
        private Matrix<Complex> data_updated;          // data_estimate of last window size of data for all the channels(introduced for openECA implementation)
        private Matrix<double>[] data_updated_real = new Matrix<double>[2];

        private int window_size;// = 10;
        private int Hankel_k;// = 6;
        private int event_rank = 10;
        private double approx_error_t = 2;
        private double ratio_approx_error;// = 1.2;
        private int tau_a;// = 6;
        private int tau_b;// = 30;

        private Vector<double>[] threshold = new Vector<double>[2];
        private Vector<double> Event_channel_index;
        private double decaying_factor = 50;
        private int instant = -300;
        private int event_instant = 0;

        private double channel_threshold = 0.7;
        private int flag_event = 0;
        private int bad_data_duration = 5;

        private double weight_0 = 0.10;
        private double weight_1 = 0.15;

        private int flag_output = 0;
        private int recalculate_count = 0;  // for recalculate
        private int recalculate_threshold = 500;
        private bool Init_flag = false;     //check whether correct first window data

        private int num_channel;

        public HankelProcessComplex(int Meas)
        {
            //Initialize each object based upon the type of measurement to facilitate simultaneous execution of SSDQ algorithm.
            window_size = ParameterForm.L;
            Hankel_k = ParameterForm.k;
            ratio_approx_error = ParameterForm.n;

            recalculate_threshold = ParameterForm.r;

            tau_a = Convert.ToInt32(ParameterForm.a);
            tau_b = Convert.ToInt32(ParameterForm.b);

            num_channel = Convert.ToInt32(Algorithm.SSDQ_config.NumChannelList[Meas]);

            threshold[0] = Vector<double>.Build.Dense(num_channel);
            threshold[1] = Vector<double>.Build.Dense(num_channel);

            data_estimate = Matrix<Complex>.Build.Dense(Convert.ToInt32(num_channel), window_size + 1);
            data_updated = Matrix<Complex>.Build.Dense(Convert.ToInt32(num_channel), window_size);
            data_observed = Matrix<Complex>.Build.Dense(Convert.ToInt32(num_channel), window_size + 1);
            flag_trusted = Matrix<double>.Build.Dense(Convert.ToInt32(num_channel), window_size + 1);
            flag_observed = Matrix<double>.Build.Dense(Convert.ToInt32(num_channel), window_size + 1);
            Init_flag = false;
            instant = -300;
            Event_channel_index = Vector<double>.Build.Dense(num_channel);

            data_updated_real[0] = Matrix<double>.Build.Dense(Convert.ToInt32(num_channel), window_size);
            data_updated_real[1] = Matrix<double>.Build.Dense(Convert.ToInt32(num_channel), window_size);
        }



        //This change introduced for openECA implementation
        public Matrix<double>[] ProcessFrame(Vector<double>[] Current_data, int numberOfFrame)
        {
            Vector<Complex> ctvector = Vector<Complex>.Build.Dense(num_channel);
            Vector<double> flag_ctvector = Vector<double>.Build.Dense(num_channel);
            Vector<double> flag_observed_ctvector = Vector<double>.Build.Dense(num_channel);

            int num_untrusted = 0;
            double tau_t = Math.Max(tau_a, tau_b * Math.Exp(-(numberOfFrame - instant) / decaying_factor));
            Vector<double> Channel_tau = Vector<double>.Build.Dense(num_channel, tau_a);

            // Step 1: get the incoming data
            for (int i = 0; i < num_channel; i++)
            {
                ctvector[i] = Complex.FromPolarCoordinates(Current_data[0][i], Current_data[1][i]);
                if (ctvector[i].Magnitude > double.Epsilon)
                {
                    flag_observed_ctvector[i] = 1;
                }
                else
                {
                    ctvector[i] = Complex.Zero;
                }

                if (Event_channel_index[i] != 0)
                {
                    Channel_tau[i] = tau_t;
                }
            }
            recalculate_count++; //Add by Hongyun and Lin

            // Step 2: Construct Hankel matrix with past and current measurements
            // the last column is set as the current observations
            data_estimate.SetColumn(window_size, ctvector);              //add raw data vector to this although later this will be updated as data_estimate gives estimated measurements at the end
            data_observed.SetColumn(window_size, ctvector);
            flag_observed.SetColumn(window_size, flag_observed_ctvector);

            // Till the first window size (L) data is retrieved , the code will not enter the following subsections and will keep getting data

            // Add by Hongyun and Lin, Initialize the window
            if (!Init_flag && numberOfFrame >= window_size)
            {
                Matrix<Complex> corrected = Programe.SAP(data_estimate.SubMatrix(0, num_channel, 1, window_size), Hankel_k, event_rank, Math.Pow(10, -3)); //correct data is provided in form of a "corrected matrix"

                data_estimate.SetSubMatrix(0, 1, corrected);
                data_updated.SetSubMatrix(0, 0, corrected);

                Matrix<double> estimated_mag = Matrix_Magnitude(data_updated);
                Matrix<Complex> estimated_ang = Matrix_Phase(data_updated);

                Vector<double> std = Vector<double>.Build.Dense(num_channel);
                for (int i = 0; i < num_channel; i++)
                {
                    threshold[0][i] = Math.Max(ArrayStatistics.StandardDeviation(estimated_mag.Row(i).ToArray()), 0.001);
                }

                Matrix<Complex> diff = estimated_ang.SubMatrix(0, num_channel, 0, window_size - 1) - estimated_ang.SubMatrix(0, num_channel, 1, window_size - 1);
                Matrix<double> temp = Matrix_Magnitude(diff);
                Vector<double> mean = Vector<double>.Build.Dense(num_channel);
                for (int i = 0; i < num_channel; i++)
                {
                    threshold[1][i] = ArrayStatistics.Mean(temp.Row(i).ToArray());
                }

                //Init_flag has been set to true here and hereafter won't enter this section of code
                Init_flag = true;
            }

            // Add by Hongyun and Lin, SAP for cumulative problem 
            if (recalculate_count == recalculate_threshold)
            {
                Matrix<Complex> corrected = Programe.SAP(data_estimate.SubMatrix(0, num_channel, 0, window_size), Hankel_k, 1, Math.Pow(10, -3)); //correct data

                data_estimate.SetSubMatrix(0, 0, corrected);

                recalculate_count = 0;
            }

            if (Init_flag && numberOfFrame > window_size)
            {
                flag_trusted.SetColumn(window_size, flag_ctvector);

                // Mag data and angle data seperately
                Matrix<double> estimated_mag = Matrix_Magnitude(data_estimate);
                Matrix<Complex> estimated_ang = Matrix_Phase(data_estimate);

                // Hankel matrix of past L observations
                Matrix<double> Hankel_matrix_mag = ExtensionFunction.ExtensionFunction.Hankel(estimated_mag.SubMatrix(0, num_channel, 0, window_size), Hankel_k);
                Matrix<Complex> Hankel_matrix_ang = ExtensionFunction.ExtensionFunction.Hankel(estimated_ang.SubMatrix(0, num_channel, 0, window_size), Hankel_k);

                Matrix<double> ct_kvectors_mag = ExtensionFunction.ExtensionFunction.Hankel(estimated_mag.SubMatrix(0, num_channel, window_size - Hankel_k + 1, Hankel_k), Hankel_k);
                Matrix<Complex> ct_kvectors_ang = ExtensionFunction.ExtensionFunction.Hankel(estimated_ang.SubMatrix(0, num_channel, window_size - Hankel_k + 1, Hankel_k), Hankel_k);

                double[] flag_ct_kvectors = (flag_trusted.SubMatrix(0, num_channel, window_size - Hankel_k + 1, Hankel_k)).ToColumnMajorArray();
                Matrix<double> Diag_kvectors = Matrix<double>.Build.DenseOfDiagonalArray(flag_ct_kvectors);

                // Step 3: conduct SVD, estimate the rank and underlying subspace
                // Magnitude
                // estimate the underlying subspace basis
                Svd<double> svd_mag = Hankel_matrix_mag.Svd();
                Vector<double> S = svd_mag.S.SubVector(0, 2);
                Matrix<double> U_mag = svd_mag.U.SubMatrix(0, num_channel * Hankel_k, 0, 2);
                int L = S.Count;

                double energy = Math.Pow(Hankel_matrix_mag.FrobeniusNorm(), 2);
                int rank_mag = 1;
                int flag_rank = 0;
                for (rank_mag = 1; rank_mag < L; rank_mag++)
                {
                    if (Math.Sqrt(1 - Math.Pow(S.SubVector(0, rank_mag).L2Norm(), 2) / energy) <= approx_error_t / 100.0)
                    {
                        flag_rank = 1;
                        break;
                    }
                }
                if (flag_rank == 0)
                {
                    rank_mag = S.Count;
                }
                // only keep the r basis
                U_mag = U_mag.SubMatrix(0, num_channel * Hankel_k, 0, rank_mag);

                // Step 4: compute the coefficient and estimate the incoming measurements
                Matrix<double> coeff_mag = (U_mag.TransposeThisAndMultiply(Diag_kvectors) * U_mag).Inverse() *
                    U_mag.TransposeThisAndMultiply(Diag_kvectors) * ct_kvectors_mag;
                Matrix<double> estimated_ctvector_mag = U_mag.SubMatrix(num_channel * (Hankel_k - 1), num_channel, 0, rank_mag) * coeff_mag;

                // Phase
                Svd<Complex> svd_ang = Hankel_matrix_ang.Svd();
                S = svd_ang.S.Real().SubVector(0, 2);
                Matrix<Complex> U_ang = svd_ang.U.SubMatrix(0, num_channel * Hankel_k, 0, 2);

                L = S.Count;

                energy = Math.Pow(Hankel_matrix_ang.FrobeniusNorm(), 2);
                int rank_ang = 1;
                flag_rank = 0;
                for (rank_ang = 1; rank_ang < L; rank_ang++)
                {
                    if (Math.Sqrt(1 - Math.Pow(S.SubVector(0, rank_ang).L2Norm(), 2) / energy) <= approx_error_t / 100.0)
                    {
                        flag_rank = 1;
                        break;
                    }
                }
                if (flag_rank == 0)
                {
                    rank_ang = S.Count;
                }
                // only keep the r basis
                U_ang = U_ang.SubMatrix(0, num_channel * Hankel_k, 0, rank_ang);

                Matrix<Complex> coeff_ang = (U_ang.ConjugateTransposeThisAndMultiply(Diag_kvectors.ToComplex()) * U_ang).Inverse() *
                    U_ang.ConjugateTransposeThisAndMultiply(Diag_kvectors.ToComplex()) * ct_kvectors_ang;
                Matrix<Complex> estimated_ctvector_ang = U_ang.SubMatrix(num_channel * (Hankel_k - 1), num_channel, 0, rank_ang) * coeff_ang;
                estimated_ctvector_ang = Matrix_Phase(estimated_ctvector_ang);

                // Step 5: determine the trusted and untrusted entries, and re-estimate the untrusted entries
                for (int i = 0; i < num_channel; i++)
                {
                    if (Math.Abs(estimated_ctvector_mag.At(i, 0) - ctvector[i].Magnitude) <= Channel_tau[i] * threshold[0][i] &&
                        Complex.Abs(estimated_ctvector_ang.At(i, 0) - (ctvector[i] / (ctvector[i].Magnitude + double.Epsilon))) <= Channel_tau[i] * threshold[1][i])
                    {
                        flag_ct_kvectors[i + (Hankel_k - 1) * num_channel] = 1;
                        flag_ctvector[i] = 1;
                    }
                    else
                    {
                        num_untrusted++;
                    }
                }

                // re-estimate the untrusted entries
                if (num_untrusted > 0)
                {
                    Diag_kvectors = Matrix<double>.Build.DenseOfDiagonalArray(flag_ct_kvectors);

                    coeff_mag = (U_mag.Transpose() * Diag_kvectors * U_mag).Inverse() *
                        U_mag.Transpose() * Diag_kvectors * ct_kvectors_mag;
                    estimated_ctvector_mag = U_mag.SubMatrix(num_channel * (Hankel_k - 1), num_channel, 0, rank_mag) * coeff_mag;

                    coeff_ang = coeff_ang = (U_ang.ConjugateTransposeThisAndMultiply(Diag_kvectors.ToComplex()) * U_ang).Inverse() *
                        U_ang.ConjugateTransposeThisAndMultiply(Diag_kvectors.ToComplex()) * ct_kvectors_ang;
                    estimated_ctvector_ang = U_ang.SubMatrix(num_channel * (Hankel_k - 1), num_channel, 0, rank_ang) * coeff_ang;
                    estimated_ctvector_ang = Matrix_Phase(estimated_ctvector_ang);

                    for (int i = 0; i < num_channel; i++)
                    {
                        if (flag_ctvector[i] == 0)
                        {
                            ctvector[i] = estimated_ctvector_mag.At(i, 0) * estimated_ctvector_ang.At(i, 0);
                            flag_ctvector[i] = weight_0;
                        }
                    }
                }
                data_estimate.SetColumn(window_size, ctvector);
                flag_trusted.SetColumn(window_size, flag_ctvector);

                // Step 6: update the matrices
                // update the data_estimate, data_observed, flag_trusted, flag_observed
                data_estimate.SetSubMatrix(0, 0, data_estimate.SubMatrix(0, num_channel, 1, window_size));
                data_observed.SetSubMatrix(0, 0, data_observed.SubMatrix(0, num_channel, 1, window_size));
                flag_trusted.SetSubMatrix(0, 0, flag_trusted.SubMatrix(0, num_channel, 1, window_size));
                flag_observed.SetSubMatrix(0, 0, flag_observed.SubMatrix(0, num_channel, 1, window_size));

                // Step 7: differentiate the event data from bad data
                if (flag_event == 0)
                {
                    if ((num_channel - num_untrusted) <= Math.Ceiling(num_channel * (1 - channel_threshold)))
                    {
                        Vector<double> consecutive_untrusted = bad_data_duration - (flag_trusted.SubMatrix(0, num_channel, window_size - bad_data_duration, bad_data_duration)).RowSums();
                        Vector<double> consecutive_observed = flag_observed.SubMatrix(0, num_channel, window_size - bad_data_duration, bad_data_duration).RowSums();
                        int sum_channel = 0;
                        for (int i = 0; i < num_channel; i++)
                        {   // check the number of channels that are consecutively observed and identified as untrusted
                            if ((consecutive_observed[i] == bad_data_duration) &&
                                (consecutive_untrusted[i] >= Math.Ceiling(bad_data_duration / 2.0)))
                            {
                                sum_channel++;
                            }
                        }

                        // if there exist multiple channels that are consucutively observed and untrusted
                        if (sum_channel >= num_channel * channel_threshold)
                        {
                            int starting_index = 0;
                            Vector<double> column_sum = (flag_trusted.SubMatrix(0, num_channel, window_size - bad_data_duration, bad_data_duration)).ColumnSums();

                            for (starting_index = 0; starting_index < bad_data_duration; starting_index++)
                            {
                                if (column_sum[starting_index] <= Math.Ceiling(num_channel * (1 - channel_threshold)))
                                {
                                    break;
                                }
                            }

                            flag_event = window_size - bad_data_duration + starting_index;
                            event_instant = numberOfFrame - bad_data_duration + starting_index + 1;
                        }
                    }
                }
                else if (flag_event > 1)
                {
                    flag_event--;
                }
                else
                {

                    flag_event--;
                    Vector<double> consecutive_untrusted = bad_data_duration - (flag_trusted.SubMatrix(0, num_channel, window_size - bad_data_duration, bad_data_duration)).RowSums();
                    Vector<double> event_channel = Vector<double>.Build.Dense(num_channel);
                    for (int i = 0; i < num_channel; i++)
                    {
                        if (consecutive_untrusted[i] >= Math.Ceiling(bad_data_duration / 2.0))
                        {
                            event_channel[i] = 1;
                        }
                    }
                    int bad_channels = (int)event_channel.Sum();

                    if (bad_channels != 0)
                    {

                        Matrix<Complex> window_data = Matrix<Complex>.Build.Dense(bad_channels, window_size);
                        for (int i = 0, ii = 0; i < num_channel; i++)
                        {
                            if (event_channel[i] == 1)
                                window_data.SetRow(ii++, data_observed.Row(i).SubVector(0, window_size));
                        }
                        Matrix<Complex> Hankel_matrix = ExtensionFunction.ExtensionFunction.Hankel(window_data, Hankel_k);

                        int num_rows = (Hankel_matrix.RowCount - bad_channels) / num_channel + 1;

                        Vector<double> error_original = Vector<double>.Build.Dense(bad_channels);
                        for (int jj = 0; jj < bad_channels; jj++)
                        {
                            Matrix<Complex> Hankel_chanel = Matrix<Complex>.Build.Dense(num_rows, Hankel_matrix.ColumnCount);
                            for (int i = 0, ii = jj; i < Hankel_chanel.RowCount; i++, ii += num_channel)
                            {
                                Hankel_chanel.SetRow(i, Hankel_matrix.Row(ii));
                            }

                            error_original[jj] = Math.Sqrt(1 - Math.Pow(Hankel_chanel.L2Norm(), 2) / Math.Pow(Hankel_chanel.FrobeniusNorm(), 2));
                        }



                        int test_trail = 150;
                        Vector<double> error_permutate = Vector<double>.Build.Dense(bad_channels);
                        var random = new Random();
                        for (int k = 0; k < test_trail; k++)
                        {
                            int[] random_index = Enumerable.Range(0, window_size).ToArray();
                            random_index = random_index.OrderBy(x => random.Next()).ToArray();
                            Matrix<Complex> permute_matrix = window_data.Clone();
                            for (int j = 0; j < window_size; j++)
                            {
                                permute_matrix.SetColumn(j, window_data.Column(random_index[j]));
                            }
                            Matrix<Complex> Hankel_permute = ExtensionFunction.ExtensionFunction.Hankel(permute_matrix, Hankel_k);

                            for (int jj = 0; jj < bad_channels; jj++)
                            {
                                Matrix<Complex> Hankel_chanel = Matrix<Complex>.Build.Dense(num_rows, Hankel_permute.ColumnCount);
                                for (int i = 0, ii = jj; i < Hankel_chanel.RowCount; i++, ii += num_channel)
                                {
                                    Hankel_chanel.SetRow(i, Hankel_permute.Row(ii));
                                }

                                error_permutate[jj] = Math.Max(error_permutate[jj], Math.Sqrt(1 - Math.Pow(Hankel_chanel.L2Norm(), 2) / Math.Pow(Hankel_chanel.FrobeniusNorm(), 2)));
                            }
                        }


                        int num_untrusted_channels = 0;
                        Vector<double> event_data_channel = Vector<double>.Build.Dense(num_channel, 0);
                        for (int i = 0, ii = 0; i < num_channel; i++)
                        {
                            if (event_channel[i] == 1)
                            {
                                if (error_permutate.PointwiseDivide(error_original)[ii++] >= ratio_approx_error)
                                {
                                    event_data_channel[i] = 1;
                                    num_untrusted_channels++;
                                }
                            }
                        }

                        if (num_untrusted_channels > 0)
                        {
                            instant = event_instant + window_size - 1;
                            flag_trusted = flag_observed.Clone();
                            flag_output = 1;
                        }

                        for (int i = 0; i < num_channel; i++)
                        {
                            if (event_data_channel[i] == 0)
                            {
                                flag_trusted.SetRow(i, Vector<double>.Build.Dense(window_size + 1, Math.Min(1, weight_1)));
                            }
                        }
                        Event_channel_index = event_data_channel.Clone();
                    }
                    //
                }
            }
            // Pre-Initialization
            else
            {
                flag_ctvector = (Vector<double>.Build.Dense(num_channel)).Add(1);
                flag_trusted.SetColumn(window_size, flag_ctvector);

                data_estimate.SetSubMatrix(0, 0, data_estimate.SubMatrix(0, num_channel, 1, window_size));
                data_observed.SetSubMatrix(0, 0, data_observed.SubMatrix(0, num_channel, 1, window_size));
                flag_trusted.SetSubMatrix(0, 0, flag_trusted.SubMatrix(0, num_channel, 1, window_size));
                flag_observed.SetSubMatrix(0, 0, flag_observed.SubMatrix(0, num_channel, 1, window_size));
            }

            if (Init_flag) //this line add by Hongyun and Lin, make sure does not oupt anything before correct the first window data
            {
                if (flag_output == 0)
                {
                    //Introduced for openECA implementation
                    data_updated.SetSubMatrix(0, 0, data_updated.SubMatrix(0, num_channel, 1, window_size - 1));
                    data_updated.SetColumn(window_size - 1, ctvector);
                }
                else
                {
                    flag_output = 0;
                    // Add by Hongyun and Lin, when event founded, correct the event data
                    Matrix<Complex> corrected = Programe.SAP(data_observed.SubMatrix(0, num_channel, 0, window_size), Hankel_k, event_rank, Math.Pow(10, -3)); // correct data

                    data_estimate.SetSubMatrix(0, 0, corrected);
                    //Introduced for openECA implementation
                    data_updated.SetSubMatrix(0, 0, corrected);
                }
            }

            for (int i = 0; i < data_updated.RowCount; i++)
            {
                for (int j = 0; j < data_updated.ColumnCount; j++)
                {
                    data_updated_real[0][i, j] = data_updated.At(i, j).Magnitude;
                    data_updated_real[1][i, j] = data_updated.At(i, j).Phase;
                }
            }

            return data_updated_real;
        }


        private static Matrix<double> Matrix_Magnitude(Matrix<Complex> X)
        {
            return (X.Real().PointwisePower(2) + X.Imaginary().PointwisePower(2)).PointwisePower(0.5);
        }

        private static Matrix<Complex> Matrix_Phase(Matrix<Complex> X)
        {
            return X.PointwiseDivide((Matrix_Magnitude(X) + double.Epsilon).ToComplex());
        }
    }
}

