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
using SSDQopenECA;
using Error_Recovery;

using System.IO;
using System.Text;

namespace HankelRobustDataEstimation
{
    [Description("HankelRobustDataEstimation: robust data estimation with low-rank Hankel structure")]
    public class HankelProcessComplex
    {
        //keep the past L estimated data and observed data
        private Matrix<Complex>  data_estimate;         // contain the past L estimations
        private Matrix<Complex>  data_observed;         // contains the past L raw observations        
        private Matrix<double>   flag_trusted;          // denote whether each entry is trusted
        private Matrix<double>   flag_observed;         // denote whether each entry is observed
        private Matrix<Complex>  data_updated;          // data_estimate of last window size of data for all the channels(introduced for openECA implementation)
        private Matrix<double>[] data_updated_real = new Matrix<double>[2];

        private int window_size;//= 10;
        private int Hankel_k;// = 6;
        private double ratio_approx_error;// = 1.2;
        private int tau_a;// = 3;
        private int tau_b;// = 30;

        private double threshold;// = 0.0015;    
        private double decaying_factor = 50;
        private int instant = -300;
        private int event_instant = 0;

        private double channel_threshold = 0.7;
        private int flag_event = 0;
        private int bad_data_duration = 5;

        private int flag_output = 0;
        private int recalculate_count = 0;  // for recalculate
        private int recalculate_threshold;  //= 2000;
        private bool Init_flag = false;     //check whether correct first window data

        private int num_channel;

        public HankelProcessComplex(int Meas)
        {
            //Initialize each object based upon the type of measurement to facilitate simultaneous execution of SSDQ algorithm.
            window_size = ParameterForm.L;
            Hankel_k = ParameterForm.k;
            threshold = 0.0021;
            ratio_approx_error = ParameterForm.n;
            recalculate_threshold = ParameterForm.r;

            tau_a = Convert.ToInt32(ParameterForm.a);
            tau_b = Convert.ToInt32(ParameterForm.b);
            if (FrameworkConfiguration.newframework)
            {
                num_channel = Convert.ToInt32(Algorithm.New_config.NumChannelList[Meas]);
            }
            else
            {
                num_channel = Convert.ToInt32(Algorithm.Stored_config.NumChannelList[Meas]);
            }

            data_estimate = Matrix<Complex>.Build.Dense(Convert.ToInt32(num_channel), window_size + 1);
            data_updated = Matrix<Complex>.Build.Dense(Convert.ToInt32(num_channel), window_size);
            data_observed = Matrix<Complex>.Build.Dense(Convert.ToInt32(num_channel), window_size + 1);
            flag_trusted = Matrix<double>.Build.Dense(Convert.ToInt32(num_channel), window_size + 1);
            flag_observed = Matrix<double>.Build.Dense(Convert.ToInt32(num_channel), window_size + 1);
            Init_flag = false;
            instant = -300;

            data_updated_real[0] = Matrix<double>.Build.Dense(Convert.ToInt32(num_channel), window_size);
            data_updated_real[1] = Matrix<double>.Build.Dense(Convert.ToInt32(num_channel), window_size);
        }

        //This change introduced for openECA implementation
        public Matrix<double>[] ProcessFrame(Vector<double>[] Current_data, int numberOfFrame)
        {
            var csv1 = new StringBuilder();

            Vector<Complex> ctvector = Vector<Complex>.Build.Dense(num_channel);
            Vector<double> flag_ctvector = Vector<double>.Build.Dense(num_channel);
            Vector<double> flag_observed_ctvector = Vector<double>.Build.Dense(num_channel);

            int num_untrusted = 0;
            double tau_t = Math.Max(tau_a, tau_b * Math.Exp(-(numberOfFrame - instant) / decaying_factor));

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
            }
            //for (int i = 0; i < num_channel; i++)
            //{
            //    var newLine = string.Format("{0},{1},", ctvector.At(i).Magnitude, ctvector.At(i).Phase * 180.0 / Math.PI);
            //    csv1.Append(newLine);
            //}
            //csv1.Append(",");

            recalculate_count++; //Add by Hongyun and Lin

            // Step 2: Construct Hankel matrix with past and current measurements
            // the last column is set as the current observations
            data_estimate.SetColumn(window_size, ctvector);              //add raw data vector to this although later this will be updated as data_estimate gives estimated measurements at the end
            data_observed.SetColumn(window_size, ctvector);
            flag_observed.SetColumn(window_size, flag_observed_ctvector);

            //Till the first window size (L) data is retrieved , the code will not enter the following subsections and will keep getting data

            // Add by Hongyun and Lin, Initialize the window
            if (numberOfFrame >= window_size && !Init_flag)
            {
                Matrix<Complex> corrected = Programe.SAP(data_estimate.SubMatrix(0, num_channel, 0, window_size), Hankel_k, 1, Math.Pow(10, -3)); //correct data is provided in form of a "corrected matrix"

                data_estimate.SetSubMatrix(0, 0, corrected);
                data_updated.SetSubMatrix(0, 0, corrected);

                Init_flag = true;           //Init_flag has been set to true here and hereafter won't enter this section of code           
            }


            if (numberOfFrame >= window_size && Init_flag)
            {
                flag_trusted.SetColumn(window_size, flag_ctvector);

                // Hankel matrix of past L observations
                Matrix<Complex> Hankel_matrix = ExtensionFunction.ExtensionFunction.Hankel(data_estimate.SubMatrix(0, num_channel, 0, window_size), Hankel_k);

                // the long vectors with past L-1 and current observations
                Matrix<Complex> ct_kvectors = ExtensionFunction.ExtensionFunction.Hankel(data_estimate.SubMatrix(0, num_channel, window_size - Hankel_k + 1, Hankel_k), Hankel_k);
                double[] flag_ct_kvectors = (flag_trusted.SubMatrix(0, num_channel, window_size - Hankel_k + 1, Hankel_k)).ToColumnMajorArray();

                // Step 3: conduct SVD, estimate the rank and underlying subspace
                Matrix<Complex> Diag_kvectors = Matrix<double>.Build.DenseOfDiagonalArray(flag_ct_kvectors).ToComplex();

                // estimate the underlying subspace basis
                Svd<Complex> svd = Hankel_matrix.Svd();
                Vector<double> singularvalue = svd.S.Real();
                Matrix<Complex> columnspace = svd.U;

                int L = singularvalue.Count;
                int rank = 1;

                // estimate the rank of the underlying subspace 
                for (int i = 1; i < L; i++)
                {
                    if (singularvalue[i] >= 0.01 * singularvalue[0])
                    {
                        rank++;
                    }
                    else { break; }
                }
                // only keep the r basis
                columnspace = columnspace.SubMatrix(0, num_channel * Hankel_k, 0, rank);


                // Step 4: compute the coefficient and estimate the incoming measurements
                Matrix<Complex> coeff = (columnspace.ConjugateTransposeThisAndMultiply(Diag_kvectors) * columnspace).Inverse() *
                    (columnspace.ConjugateTransposeThisAndMultiply(Diag_kvectors) * ct_kvectors);
                Matrix<Complex> estimated_ctvector = columnspace.SubMatrix(num_channel * (Hankel_k - 1), num_channel, 0, rank) * coeff;


                // Step 5: determine the trusted and untrusted entries, and re-estimate the untrusted entries
                for (int i = 0; i < num_channel; i++)
                {
                    if (Complex.Abs(estimated_ctvector.At(i, 0) - ctvector[i]) <= tau_t * threshold)
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
                    Diag_kvectors = Matrix<double>.Build.DenseOfDiagonalArray(flag_ct_kvectors).ToComplex();
                    coeff = (columnspace.ConjugateTransposeThisAndMultiply(Diag_kvectors) * columnspace).Inverse() *
                        (columnspace.ConjugateTransposeThisAndMultiply(Diag_kvectors) * ct_kvectors);
                    estimated_ctvector = columnspace.SubMatrix(num_channel * (Hankel_k - 1), num_channel, 0, rank) * coeff;

                    for (int i = 0; i < num_channel; i++)
                    {
                        if (flag_ctvector[i] == 0)
                        {
                            ctvector[i] = estimated_ctvector.At(i, 0);
                            flag_ctvector[i] = 0.1;
                        }
                    }
                }
                data_estimate.SetColumn(window_size, ctvector);
                flag_trusted.SetColumn(window_size, flag_ctvector);


                // Step 6: update the matrices         
                // update the data_estimate, data_observed, flag_trusted
                data_estimate.SetSubMatrix(0, 0, data_estimate.SubMatrix(0, num_channel, 1, window_size));
                data_observed.SetSubMatrix(0, 0, data_observed.SubMatrix(0, num_channel, 1, window_size));
                flag_trusted.SetSubMatrix(0, 0, flag_trusted.SubMatrix(0, num_channel, 1, window_size));
                flag_observed.SetSubMatrix(0, 0, flag_observed.SubMatrix(0, num_channel, 1, window_size));

                // Step 7: differentiate the event data from bad data
                if (flag_event == 0)
                {
                    if (num_untrusted >= num_channel * channel_threshold)
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
                    Matrix<Complex> window_data = data_observed.SubMatrix(0, num_channel, 0, window_size);
                    Hankel_matrix = ExtensionFunction.ExtensionFunction.Hankel(window_data, Hankel_k);
                    double approx_error = Math.Sqrt(1 - Math.Pow(Hankel_matrix.L2Norm(), 2) / Math.Pow(Hankel_matrix.FrobeniusNorm(), 2));
                    double rand_approx_error = 0;
                    for (int i = 1; i <= 500; i++)
                    {
                        int[] random_index = Enumerable.Range(0, window_size).ToArray();
                        var random = new Random();
                        random_index = random_index.OrderBy(x => random.Next()).ToArray();
                        Matrix<Complex> permute_matrix = window_data.Clone();
                        for (int j = 0; j < window_size; j++)
                        {
                            permute_matrix.SetColumn(j, window_data.Column(random_index[j]));
                        }
                        Matrix<Complex> Hankel_permute = ExtensionFunction.ExtensionFunction.Hankel(permute_matrix, Hankel_k);
                        rand_approx_error = Math.Max(rand_approx_error,
                            Math.Sqrt(1 - Math.Pow(Hankel_permute.L2Norm(), 2) / Math.Pow(Hankel_permute.FrobeniusNorm(), 2)));
                    }

                    if (rand_approx_error / approx_error >= ratio_approx_error)
                    {
                        //Matrix<Complex> corrected = Programe.SAP(data_observed.SubMatrix(0, num_channel, 0, window_size), Hankel_k, 3, Math.Pow(10, -3)); // correct data
                        //data_estimate.SetSubMatrix(0, 0, corrected);
                        //data_observed.SetSubMatrix(0, 0, corrected);

                        instant = event_instant + window_size - 1;
                        flag_trusted = flag_observed.Clone();
                        flag_output = 1;
                    }
                }
            }
            else
            {
                flag_ctvector = (Vector<double>.Build.Dense(num_channel)).Add(1);
                flag_trusted.SetColumn(window_size, flag_ctvector);

                data_estimate.SetSubMatrix(0, 0, data_estimate.SubMatrix(0, num_channel, 1, window_size));
                data_observed.SetSubMatrix(0, 0, data_observed.SubMatrix(0, num_channel, 1, window_size));
                flag_trusted.SetSubMatrix(0, 0, flag_trusted.SubMatrix(0, num_channel, 1, window_size));
                flag_observed.SetSubMatrix(0, 0, flag_observed.SubMatrix(0, num_channel, 1, window_size));
            }

            // Add by Hongyun and Lin, SAP for cumulative problem 
            if (recalculate_count == recalculate_threshold)
            {
                Matrix<Complex> corrected = Programe.SAP(data_estimate.SubMatrix(0, num_channel, 0, window_size), Hankel_k, 1, Math.Pow(10, -3)); //correct data

                data_estimate.SetSubMatrix(0, 0, corrected);

                recalculate_count = 0;
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
                    Matrix<Complex> corrected = Programe.SAP(data_observed.SubMatrix(0, num_channel, 0, window_size), Hankel_k, 3, Math.Pow(10, -3)); // correct data
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
            //for (int i = 0; i < num_channel; i++)
            //{
            //    var newLine = string.Format("{0},{1},", data_updated_real[0][i, 0], data_updated_real[1][i, 0] * 180.0 / Math.PI);
            //    csv1.Append(newLine);
            //}
            //csv1.AppendLine("");
            //File.AppendAllText(@"C:\Users\Jacob\Desktop\1.csv", csv1.ToString());

            return data_updated_real;
        }
    }
}

