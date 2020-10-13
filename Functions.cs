// ************************************************************************************************************
//************************************SSDQ EPRI openECA Analytic********************************
//Code for certain functions used in Hankel Robust Data Estimation for the SSDQ application.
//Company- Electric Power Research Institute (EPRI)
//Algorithm Developed by-Rensselaer Polytechnic Institute
//File:Functions.cs
//Description:This code segment defines various functions required by the SSDQ algorithm (HankelProcess.cs).
//*************************************************************************************************************
using System;
using System.Collections.Generic;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Factorization;

namespace Error_Recovery
{
    class Programe
    {
        public static Matrix<double> SAP(Matrix<double> x_p, int n1, int true_rank, double eps)
        {
            int n_row = x_p.RowCount; // get row count which is number of channels
            int n_col = x_p.ColumnCount;
            int n2 = n_col - n1 + 1;
            double eta = 0.5 * Math.Sqrt(n1 * n2);
            true_rank = Math.Min(true_rank, n2 - 1);

            Matrix<double> omega = Matrix<double>.Build.Dense(n_row, n_col);
            for (int i = 0; i < n_row; i++)   //omega = (x_p~=0);
            {
                for (int j = 0; j < n_col; j++)
                {
                    if (x_p[i, j].Equals(0.0))
                    {
                        omega[i, j] = 0;
                    }
                    else
                    {
                        omega[i, j] = 1;
                    }
                }
            }

            //This equal to build a matrix calcuate the rate of how many times 1 appears in every row
            Matrix<double> ones = Matrix<double>.Build.Dense(n_col, 1, 1);
            Matrix<double> p = omega * ones / n_col;

            Matrix<double> x = Matrix<double>.Build.Dense(n_row, n_col); //Create a n_row*n_col Matrix with all 0

            Matrix<double> diag_result = Matrix<double>.Build.Dense(p.RowCount, p.RowCount);
            diag_result.SetDiagonal(p.Column(0).PointwisePower(-1));

            Vector<double> repetition_num = F_repetition_num(n1, n2);

            Matrix<double> w = diag_result * x_p;

            int r = 0;
            while (r < true_rank)
            {
                Matrix<double> W = F_Hankel(w, n1); //W = F_Hankel(diag(1./p)*x_p,n1); % initialize W

                Matrix<double>[] Result = F_svds(W, 2);    //[~,S,~] = F_svdsecon(W,r+1);

                Matrix<double> S = Result[1];
                Vector<double> s = S.Diagonal();

                double T = 2 * (s[r] + s[r + 1]) / eta;

                for (int c = 1; c <= 200; c++)
                {
                    Matrix<double> g = omega.PointwiseMultiply(x_p - x);

                    Matrix<double> e = g.Clone();   //e = g.*(abs(g)>T);
                    for (int i = 0; i < e.RowCount; i++)
                    {
                        for (int j = 0; j < e.ColumnCount; j++)
                        {
                            if (Math.Abs(e[i, j]) <= T)
                            {
                                e[i, j] = 0;
                            }
                        }
                    }

                    Matrix<double> x_pre = x.Clone();

                    w = x + diag_result * (g - e);

                    W = F_Hankel(w, n1);   //Construct the Hankel matrix

                    Result = F_svds(W, 7);  //Compute the largest r+1 singular value components
                    Matrix<double> U = Result[0].SubMatrix(0, Result[0].RowCount, 0, r + 2);
                    S = Result[1].SubMatrix(0, r + 2, 0, r + 2);
                    Matrix<double> V = Result[2].SubMatrix(0, Result[2].RowCount, 0, r + 2);

                    s = Result[1].Diagonal();

                    x = F_Hankel_inv(U, S, V, r + 1, n_row, repetition_num);

                    T = (Math.Pow(0.9, c) * s[r] + s[r + 1]) / eta;
                    if ((x - x_pre).FrobeniusNorm() / x_pre.FrobeniusNorm() < eps)
                    {
                        break;
                    }
                }
                if (s[r + 1] / (2 * eta) < eps)
                {
                    return x;
                }
                r++;
            }
            return x;
        }

        public static Matrix<Complex> SAP(Matrix<Complex> x_p, int n1, int true_rank, double eps)
        {
            int n_row = x_p.RowCount; // get row count which is number of channels
            int n_col = x_p.ColumnCount;
            int n2 = n_col - n1 + 1;
            double eta = 0.5 * Math.Sqrt(n1 * n2);
            true_rank = Math.Min(true_rank, n2 - 1);

            Matrix<Complex> omega = Matrix<Complex>.Build.Dense(n_row, n_col);
            for (int i = 0; i < n_row; i++)   //omega = (x_p~=0);
            {
                for (int j = 0; j < n_col; j++)
                {
                    if (x_p[i, j].Equals(0.0))
                    {
                        omega[i, j] = 0;
                    }
                    else
                    {
                        omega[i, j] = 1;
                    }
                }
            }

            //This equal to build a matrix calcuate the rate of how many times 1 appears in every row
            Matrix<Complex> ones = Matrix<Complex>.Build.Dense(n_col, 1, 1);
            Matrix<Complex> p = omega * ones / n_col;

            Matrix<Complex> x = Matrix<Complex>.Build.Dense(n_row, n_col); //Create a n_row*n_col Matrix with all 0

            Matrix<Complex> diag_result = Matrix<Complex>.Build.Dense(p.RowCount, p.RowCount);
            diag_result.SetDiagonal(p.Column(0).PointwisePower(-1));

            Vector<double> repetition_num = F_repetition_num(n1, n2);

            Matrix<Complex> w = diag_result * x_p;

            int r = 0;
            while (r < true_rank)
            {
                Matrix<Complex> W = F_Hankel(w, n1); //W = F_Hankel(diag(1./p)*x_p,n1); % initialize W

                Matrix<Complex>[] Result = F_svds(W, 2);    //[~,S,~] = F_svdsecon(W,r+1);

                Matrix<double> S = Result[1].Real();
                Vector<double> s = S.Diagonal();

                double T = 2 * (s[r] + s[r + 1]) / eta;

                for (int c = 1; c <= 200; c++)
                {
                    Matrix<Complex> g = omega.PointwiseMultiply(x_p - x);

                    Matrix<Complex> e = g.Clone();   //e = g.*(abs(g)>T);
                    for (int i = 0; i < e.RowCount; i++)
                    {
                        for (int j = 0; j < e.ColumnCount; j++)
                        {
                            if (Complex.Abs(e[i, j]) <= T)
                            {
                                e[i, j] = 0;
                            }
                        }
                    }

                    Matrix<Complex> x_pre = x.Clone();

                    w = x + diag_result * (g - e);

                    W = F_Hankel(w, n1);   //Construct the Hankel matrix

                    Result = F_svds(W, 7);  //Compute the largest r+1 singular value components
                    Matrix<Complex> U = Result[0].SubMatrix(0, Result[0].RowCount, 0, r + 2);
                    S = Result[1].Real().SubMatrix(0, r + 2, 0, r + 2);
                    Matrix<Complex> V = Result[2].SubMatrix(0, Result[2].RowCount, 0, r + 2);

                    s = Result[1].Real().Diagonal();

                    x = F_Hankel_inv(U, S, V, r + 1, n_row, repetition_num);

                    T = (Math.Pow(0.9, c) * s[r] + s[r + 1]) / eta;
                    if ((x - x_pre).FrobeniusNorm() / x_pre.FrobeniusNorm() < eps)
                    {
                        break;
                    }
                }
                if (s[r + 1] / (2 * eta) < eps)
                {
                    return x;
                }
                r++;
            }
            return x;
        }

        static Matrix<T> F_Hankel<T>(Matrix<T> x, int n1) where T : struct, IEquatable<T>, IFormattable
        {
            int n_row = x.RowCount; // [n_row,n_col] = size(x); 
            int n_col = x.ColumnCount;
            int n2 = n_col + 1 - n1;  // the number of columns in the Hankel matrix

            Matrix<T> L = Matrix<T>.Build.Dense(n_row * n1, n2); // L = zeros(n_row*n1,n2);
            for (int i = 0; i < n2; i++)
            {
                L.SetColumn(i, Slice(x, n_row * ((i + 1) - 1) + 1, n_row * ((i + 1) + n1 - 1)));
            }
            return L;
        }

        static Matrix<double> F_Hankel_inv(Matrix<double> U, Matrix<double> S, Matrix<double> V, int r, int n_c, Vector<double> repetition_num)
        {
            int n1 = U.RowCount / n_c;
            int n2 = V.RowCount;
            Matrix<double> x = Matrix<double>.Build.Dense(n_c, n1 + n2 - 1);

            for (int i = 0; i < r; i++)
            {
                Matrix<double> Ut = Reshape(U.Column(i), n_c, n1);

                for (int j = 0; j < n_c; j++)
                {
                    x.SetRow(j, x.Row(j) + S.At(i, i) * Conv(Ut.Row(j), V.Column(i).Conjugate()));
                }
            }

            Matrix<double> diag_result = Matrix<double>.Build.DenseDiagonal(repetition_num.Count, 0);
            diag_result.SetDiagonal(repetition_num.PointwisePower(-1));

            return x * diag_result;
        }

        static Matrix<Complex> F_Hankel_inv(Matrix<Complex> U, Matrix<double> S, Matrix<Complex> V, int r, int n_c, Vector<double> repetition_num)
        {
            int n1 = U.RowCount / n_c;
            int n2 = V.RowCount;
            Matrix<Complex> x = Matrix<Complex>.Build.Dense(n_c, n1 + n2 - 1);

            for (int i = 0; i < r; i++)
            {
                Matrix<Complex> Ut = Reshape(U.Column(i), n_c, n1);

                for (int j = 0; j < n_c; j++)
                {
                    x.SetRow(j, x.Row(j) + S.At(i, i) * Conv(Ut.Row(j), V.Column(i).Conjugate()));
                }
            }

            Matrix<double> diag_result = Matrix<double>.Build.DenseDiagonal(repetition_num.Count, 0);
            diag_result.SetDiagonal(repetition_num.PointwisePower(-1));

            return x * diag_result.ToComplex();
        }

        static Vector<T> Slice<T>(Matrix<T> M, int start, int end) where T : struct, IEquatable<T>, IFormattable // start ,end is matlab start number 
        {
            int col = M.ColumnCount;
            int row = M.RowCount;
            List<T> numbers = new List<T>();
            for (int j = 0; j < col; j++) // add all the number in matrix to list with column order
            {
                for (int i = 0; i < row; i++)
                {
                    numbers.Add(M[i, j]);
                }
            }

            int length = end - start + 1;
            Vector<T> v = Vector<T>.Build.Dense(length);

            for (int i = 0; i < length; i++)
            {
                v[i] = numbers[start - 1 + i];
            }

            return v;
        }

        static Matrix<T>[] F_svds<T>(Matrix<T> X, int mode) where T : struct, IEquatable<T>, IFormattable    // this is equal to svdsecon(matlab svdsecon != svds )
        {
            bool iftrue = true;

            if (mode != 7) iftrue = false;

            Matrix<T>[] result = new Matrix<T>[3];

            Svd<T> svd = X.Svd(iftrue);

            Matrix<T> U = svd.U;
            Matrix<T> S = svd.W;
            Matrix<T> V = svd.VT.ConjugateTranspose();

            result[0] = U;
            result[1] = S;
            result[2] = V;

            return result;
        }

        static Vector<double> Conv(Vector<double> u, Vector<double> v)
        {
            Vector<double> w = Vector<double>.Build.Dense(u.Count + v.Count - 1, 0);
            for (int i = 0; i < u.Count; i++)
            {
                for (int j = 0; j < v.Count; j++)
                {
                    w[i + j] += u[i] * v[j];
                }
            }
            return w;
        }

        static Vector<Complex> Conv(Vector<Complex> u, Vector<Complex> v)
        {
            Vector<Complex> w = Vector<Complex>.Build.Dense(u.Count + v.Count - 1, 0);
            for (int i = 0; i < u.Count; i++)
            {
                for (int j = 0; j < v.Count; j++)
                {
                    w[i + j] += u[i] * v[j];
                }
            }
            return w;
        }

        static Matrix<T> Reshape<T>(Vector<T> x, int row, int col) where T : struct, IEquatable<T>, IFormattable
        {
            Matrix<T> y = Matrix<T>.Build.Dense(row, col);

            int n = 0;
            int m = 0;
            for (int i = 0; i < x.Count; i++)
            {
                y[n++, m] = x[i];
                if (n == row)
                {
                    n = 0;
                    m++;
                }
            }

            return y;
        }

        static Vector<double> F_repetition_num(int n1, int n2)
        {
            if (n1 > n2)
            {
                int temp = n1;
                n1 = n2;
                n2 = temp;
            }

            int n = n1 + n2 - 1;

            Vector<double> num = Vector<double>.Build.Dense(n);

            for (int a = 1; a < n + 1; a++)
            {
                if (a <= n1)
                {
                    num[a - 1] = a;
                }
                else if (a >= n2)
                {
                    num[a - 1] = n2 + n1 - a;
                }
                else
                {
                    num[a - 1] = n1;
                }
            }
            return num;
        }
    }
}
