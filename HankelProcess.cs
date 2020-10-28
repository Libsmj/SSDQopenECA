// ************************************************************************************************************
//************************************SSDQopenECA Analytic********************************
//Code for Hankel Robust Data Estimation of the Streaming Synchrophasor Data Quality and Conditioning application.
//Company- Electric Power Research Institute (EPRI)
//Manager- Dr. Evangelos Farantatos
//Algorithm & Code developed by-Rensselaer Polytechnic Institute
//Modified by- Tapas Kumar Barik, Virginia Polytechnic & State University, EPRI Summer Intern 2019
//File:HankelProcess.cs
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
    public class HankelProcess
    {
        //keep the past L estimated data and observed data
        private Matrix<double> data_estimate;           // contain the past L estimations
        private Matrix<double> data_observed;           // contains the past L raw observations
        private Matrix<double> flag_trusted;            // denote whether each entry is trusted
        private Matrix<double> flag_observed;           // denote whether each entry is observed
        private Matrix<double> data_updated;            // submatrix of last window size of data for all the channels(introduced for openECA implementation)

        private int window_size = 10;
        private int Hankel_k = 6;
        private int event_rank = 10;
        private double approx_error_t = 2;
        private double ratio_approx_error = 1.2;
        private int tau_a = 6;
        private int tau_b = 30;

        private Vector<double> threshold;
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

        public HankelProcess(int Meas)
        {
            //Initialize each object based upon the type of measurement to facilitate simultaneous execution of SSDQ algorithm.
            num_channel = Convert.ToInt32(Algorithm.SSDQ_config.NumChannelList[Meas]);
            window_size = ParameterForm.L;
            Hankel_k = ParameterForm.k;
            if (Meas == 1 || Meas == 3)
            {
                //For Angles the threshold is the mean difference of two consecutive frames in radians
                threshold = Vector<double>.Build.Dense(num_channel, 0.0052);
                ratio_approx_error = 1.5 * ParameterForm.n;
            }
            else if (Meas == 0 || Meas == 2)
            {
                //For Magnitudes the threshold is the standard deviation of two consecutive frames.
                threshold = Vector<double>.Build.Dense(num_channel, 0.0015);
                ratio_approx_error = ParameterForm.n;
            }
            else if (Meas == 4)
            {
                threshold = Vector<double>.Build.Dense(num_channel, 0.0015);
                ratio_approx_error = ParameterForm.n;
            }

            recalculate_threshold = ParameterForm.r;

            tau_a = Convert.ToInt32(ParameterForm.a);
            tau_b = Convert.ToInt32(ParameterForm.b);

            Event_channel_index = Vector<double>.Build.Dense(num_channel);

            data_estimate = Matrix<double>.Build.Dense(num_channel, window_size + 1);
            data_updated = Matrix<double>.Build.Dense(num_channel, window_size);
            data_observed = Matrix<double>.Build.Dense(num_channel, window_size + 1);
            flag_trusted = Matrix<double>.Build.Dense(num_channel, window_size + 1);
            flag_observed = Matrix<double>.Build.Dense(num_channel, window_size + 1);
            Init_flag = false;
            instant = -300;
        }

        public Matrix<double> Initialize()
        {
            return data_updated;
        }

        public Matrix<double> ProcessFrame(Vector<double> Current_data, int numberOfFrame)
        {
            Vector<double> ctvector = Vector<double>.Build.Dense(num_channel);
            Vector<double> flag_ctvector = Vector<double>.Build.Dense(num_channel);
            Vector<double> flag_observed_ctvector = Vector<double>.Build.Dense(num_channel);

            int num_untrusted = 0;
            double tau_t = Math.Max(tau_a, tau_b * Math.Exp(-(numberOfFrame - instant) / decaying_factor));
            Vector<double> Channel_tau = Vector<double>.Build.Dense(num_channel, tau_a);

            // Step 1: get the incoming data
            for (int i = 0; i < num_channel; i++)
            {
                ctvector[i] = Current_data[i];
                if (ctvector[i] != 0)
                {
                    flag_observed_ctvector[i] = 1;
                }

                if (Event_channel_index[i] != 0)
                {
                    Channel_tau[i] = tau_t;
                }
            }

            // Step 2: Construct Hankel matrix with past and current measurements
            // the last column is set as the current observations
            data_estimate.SetColumn(window_size, ctvector);              //add raw data vector to this although later this will be updated as data_estimate gives estimated measurements at the end
            data_observed.SetColumn(window_size, ctvector);
            flag_observed.SetColumn(window_size, flag_observed_ctvector);

            // Till the first window size (L) data is retrieved , the code will not enter the following subsections and will keep getting data

            // Add by Hongyun and Lin, Initialize the window
            if (!Init_flag)
            {
                if (numberOfFrame == window_size)
                {
                    Matrix<double> corrected = Programe.SAP(data_estimate.SubMatrix(0, num_channel, 1, window_size), Hankel_k, event_rank, Math.Pow(10, -3)); //correct data is provided in form of a "corrected matrix"

                    data_estimate.SetSubMatrix(0, 1, corrected);
                    data_updated.SetSubMatrix(0, 0, corrected);

                    //Init_flag has been set to true here and hereafter won't enter this section of code
                    Init_flag = true;
                }
                flag_ctvector = (Vector<double>.Build.Dense(num_channel)).Add(1);
                flag_trusted.SetColumn(window_size, flag_ctvector);

                data_estimate.SetSubMatrix(0, 0, data_estimate.SubMatrix(0, num_channel, 1, window_size));
                data_observed.SetSubMatrix(0, 0, data_observed.SubMatrix(0, num_channel, 1, window_size));
                flag_trusted.SetSubMatrix(0, 0, flag_trusted.SubMatrix(0, num_channel, 1, window_size));
                flag_observed.SetSubMatrix(0, 0, flag_observed.SubMatrix(0, num_channel, 1, window_size));

                return data_updated;
            }

            // Add by Hongyun and Lin, SAP for cumulative problem
            recalculate_count++;
            if (recalculate_count == recalculate_threshold)
            {
                Matrix<double> corrected = Programe.SAP(data_observed.SubMatrix(0, num_channel, 0, window_size), Hankel_k, 1, Math.Pow(10, -3)); //correct data

                data_estimate.SetSubMatrix(0, 0, corrected);

                recalculate_count = 0;
            }


            flag_trusted.SetColumn(window_size, flag_ctvector);

            // Hankel matrix of past L observations
            Matrix<double> Hankel_matrix = ExtensionFunction.ExtensionFunction.Hankel(data_estimate.SubMatrix(0, num_channel, 0, window_size), Hankel_k);

            Matrix<double> ct_kvectors_mag = ExtensionFunction.ExtensionFunction.Hankel(data_estimate.SubMatrix(0, num_channel, window_size - Hankel_k + 1, Hankel_k), Hankel_k);

            double[] flag_ct_kvectors = (flag_trusted.SubMatrix(0, num_channel, window_size - Hankel_k + 1, Hankel_k)).ToColumnMajorArray();
            Matrix<double> Diag_kvectors = Matrix<double>.Build.DenseOfDiagonalArray(flag_ct_kvectors);

            // Step 3: conduct SVD, estimate the rank and underlying subspace
            // estimate the underlying subspace basis
            Svd<double> svd = Hankel_matrix.Svd();
            Vector<double> S = svd.S.SubVector(0, 2);
            Matrix<double> U = svd.U.SubMatrix(0, num_channel * Hankel_k, 0, 2);
            int L = S.Count;

            double energy = Math.Pow(Hankel_matrix.FrobeniusNorm(), 2);
            int rank = 1;
            int flag_rank = 0;
            for (rank = 1; rank < L; rank++)
            {
                if (Math.Sqrt(1 - Math.Pow(S.SubVector(0, rank).L2Norm(), 2) / energy) <= approx_error_t / 100.0)
                {
                    flag_rank = 1;
                    break;
                }
            }
            if (flag_rank == 0)
            {
                rank = S.Count;
            }
            // only keep the r basis
            U = U.SubMatrix(0, num_channel * Hankel_k, 0, rank);

            // Step 4: compute the coefficient and estimate the incoming measurements
            Matrix<double> coeff = (U.TransposeThisAndMultiply(Diag_kvectors) * U).Inverse() *
                U.TransposeThisAndMultiply(Diag_kvectors) * ct_kvectors_mag;
            Matrix<double> estimated_ctvector_mag = U.SubMatrix(num_channel * (Hankel_k - 1), num_channel, 0, rank) * coeff;

            // Step 5: determine the trusted and untrusted entries, and re-estimate the untrusted entries
            for (int i = 0; i < num_channel; i++)
            {
                if (Math.Abs(estimated_ctvector_mag.At(i, 0) - ctvector[i]) <= Channel_tau[i] * threshold[i])
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

                coeff = (U.Transpose() * Diag_kvectors * U).Inverse() *
                    U.Transpose() * Diag_kvectors * ct_kvectors_mag;
                estimated_ctvector_mag = U.SubMatrix(num_channel * (Hankel_k - 1), num_channel, 0, rank) * coeff;

                for (int i = 0; i < num_channel; i++)
                {
                    if (flag_ctvector[i] == 0)
                    {
                        ctvector[i] = estimated_ctvector_mag.At(i, 0);
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
                    Matrix<double> window_data = Matrix<double>.Build.Dense(bad_channels, window_size);
                    for (int i = 0, ii = 0; i < num_channel; i++)
                    {
                        if (event_channel[i] == 1)
                            window_data.SetRow(ii++, data_observed.Row(i).SubVector(0, window_size));
                    }
                    Hankel_matrix = ExtensionFunction.ExtensionFunction.Hankel(window_data, Hankel_k);

                    int num_rows = (Hankel_matrix.RowCount - bad_channels) / num_channel + 1;

                    Vector<double> error_original = Vector<double>.Build.Dense(bad_channels);
                    for (int jj = 0; jj < bad_channels; jj++)
                    {
                        Matrix<double> Hankel_chanel = Matrix<double>.Build.Dense(num_rows, Hankel_matrix.ColumnCount);
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
                        Matrix<double> permute_matrix = window_data.Clone();
                        for (int j = 0; j < window_size; j++)
                        {
                            permute_matrix.SetColumn(j, window_data.Column(random_index[j]));
                        }
                        Matrix<double> Hankel_permute = ExtensionFunction.ExtensionFunction.Hankel(permute_matrix, Hankel_k);

                        for (int jj = 0; jj < bad_channels; jj++)
                        {
                            Matrix<double> Hankel_chanel = Matrix<double>.Build.Dense(num_rows, Hankel_permute.ColumnCount);
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
            }

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
                Matrix<double> corrected = Programe.SAP(data_observed.SubMatrix(0, num_channel, 0, window_size), Hankel_k, event_rank, Math.Pow(10, -3)); // correct data

                data_estimate.SetSubMatrix(0, 0, corrected);
                //Introduced for openECA implementation
                data_updated.SetSubMatrix(0, 0, corrected);
            }

            return data_updated;
        }

        static void Disp(Matrix<double> x)
        {
            Console.WriteLine(x.RowCount + " x " + x.ColumnCount + " Double Matrix");
            for (int i = 0; i < x.RowCount; i++)
            {
                for (int j = 0; j < x.ColumnCount; j++)
                {
                    if (x.At(i, j) >= 0)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("-");
                    }
                    Console.Write(Math.Abs(x.At(i, j)).ToString("0.0000").Substring(0, 6) + "   ");
                }
                Console.WriteLine();
            }
        }

        static void Disp(Vector<double> x)
        {
            Console.WriteLine(x.Count + " Double Vector");
            for (int i = 0; i < x.Count; i++)
            {
                if (x.At(i) >= 0)
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.Write("-");
                }
                Console.WriteLine(Math.Abs(x.At(i)).ToString("0.0000").Substring(0, 6));
            }
        }
    }
}

namespace ExtensionFunction
{
    public static class ExtensionFunction
    {
        // function: SubArray
        public static T[] SubArray<T>(this T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }

        // function: construct the corresponding Hankel structure from the input matrix
        public static Matrix<T> Hankel<T>(this Matrix<T> matrix, int num_vector) where T : struct, IEquatable<T>, IFormattable
        {
            int n_row = matrix.RowCount;
            int n_col = matrix.ColumnCount;

            //the number of columns in the Hankel matrix
            int Hankel_column = n_col + 1 - num_vector;
            Matrix<T> Hankel_matrix = Matrix<T>.Build.Dense(n_row * num_vector, Hankel_column);
            T[] vector = matrix.ToColumnMajorArray();
            for (int i = 0; i < Hankel_column; i++)
            {
                Hankel_matrix.SetColumn(i, SubArray(vector, n_row * i, n_row * num_vector));
            }
            return Hankel_matrix;
        }
    }
}

