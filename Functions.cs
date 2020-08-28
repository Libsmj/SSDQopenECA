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
using System.Threading;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Factorization;

namespace Error_Recovery
{
    class Programe
    {
        public static Matrix<double> SAP(Matrix<double> x_p, int n1, int r_true, double eps)
        {
            int n_row = x_p.RowCount; // get row count which is number of channels
            int n_col = x_p.ColumnCount;

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

            Matrix<double> W = F_Hankel(diag_result * x_p, n1);         //Initialize W

            int r = 1;
            while (r <= r_true)
            {
                Matrix<double>[] Result = F_svds(W, 2);    //[~,S,~] = F_svdsecon(W,r+1);

                Matrix<double> S = Result[1];
                Vector<double> s = S.Diagonal();

                double T = 2 * (s[r - 1] + s[r]) / (Math.Sqrt(n_row * n_col)); //T = 1*(s(r)+s(r+1))/(sqrt(n_row*n_col));

                for (int c = 1; c <= 50; c++)
                {
                    Matrix<double> g = omega.PointwiseMultiply((x_p - x));

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
                    W = F_Hankel(x + diag_result * (g - e), n1);   //Construct the Hankel matrix
                    
                    Result = F_svds(W, 7);  //Compute the largest r+1 singular value components
                    Matrix<double> U = Result[0].SubMatrix(0, Result[0].RowCount, 0, r);
                    S = Result[1].SubMatrix(0, r, 0, r);
                    Matrix<double> V = Result[2].SubMatrix(0, Result[2].RowCount, 0, r);

                    Matrix<double> L = U * S * V.Transpose();
                    s = Result[1].Diagonal();
                    x = F_Hankel_inv(L, n_row);  //Hankel pseudoinverse Operator

                    double T_pre = T;
                    T = 2 * ((Math.Pow(0.8, c) * s[r - 1] + s[r]) / Math.Sqrt(n_row * n_col)); //T = ((0.8) ^ c * s(r) + s(r + 1)) / (sqrt(ch_n * n));
                    if ((x - x_pre).FrobeniusNorm() / x_pre.FrobeniusNorm() < Math.Pow(10, -6) || Math.Abs(T - T_pre) < eps)
                    {
                        break;
                    }
                }
                if ((s[r] / Math.Sqrt(n_row * n_col)) < eps)
                {
                    return x;
                }
                r++;
            }
            return x;
        }

        public static Matrix<Complex> SAP(Matrix<Complex> x_p, int n1, int r_true, double eps)
        {
            int n_row = x_p.RowCount; // get row count which is number of channels
            int n_col = x_p.ColumnCount;

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

            Matrix<Complex> x = Matrix<Complex>.Build.Dense(n_row, n_col); //Create a n_row*n_col Matrix with all 0

            Matrix<double> diag_result = Matrix<double>.Build.Dense(p.RowCount, p.RowCount);
            diag_result.SetDiagonal(p.Column(0).PointwisePower(-1));

            Matrix<Complex> W = F_Hankel(diag_result.ToComplex() * x_p, n1);         //Initialize W

            int r = 1;
            while (r <= r_true)
            {
                Matrix<Complex>[] Result = F_svds(W, 2);    //[~,S,~] = F_svdsecon(W,r+1);

                Matrix<double> S = Result[1].Real();
                Vector<double> s = S.Diagonal();

                double T = 2 * (s[r - 1] + s[r]) / (Math.Sqrt(n_row * n_col));

                for (int c = 1; c <= 50; c++)
                {
                    Matrix<Complex> g = omega.ToComplex().PointwiseMultiply(x_p - x);

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
                    W = F_Hankel(x + diag_result.ToComplex() * (g - e), n1);   //Construct the Hankel matrix

                    Result = F_svds(W, 7);  //Compute the largest r+1 singular value components
                    Matrix<Complex> U = Result[0].SubMatrix(0, Result[0].RowCount, 0, r);
                    S = Result[1].Real().SubMatrix(0, r, 0, r);
                    Matrix<Complex> V = Result[2].SubMatrix(0, Result[2].RowCount, 0, r);

                    Matrix<Complex> L = U * S.ToComplex() * V.ConjugateTranspose();
                    s = Result[1].Real().Diagonal();
                    x = F_Hankel_inv(L, n_row);  //Hankel pseudoinverse Operator

                    double T_pre = T;
                    T = 2 * ((Math.Pow(0.8, c) * s[r - 1] + s[r]) / Math.Sqrt(n_row * n_col));
                    if ((x - x_pre).FrobeniusNorm() / x_pre.FrobeniusNorm() < Math.Pow(10, -6) || Math.Abs(T - T_pre) < eps)
                    {
                        break;
                    }
                }
                if ((s[r] / Math.Sqrt(n_row * n_col)) < eps)
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

        static Matrix<double> F_Hankel_inv(Matrix<double> L, int n_ori_row)
        {
            int n_row = L.RowCount; // get row 
            int n2 = L.ColumnCount; // get column
            int n1 = n_row / n_ori_row;  //the number of observation Vectors in each column

            //Multi-Threading -------------------------------------------
            MP_slice<double> operation = new MP_slice<double>(L, n_ori_row);
            operation.Perform();
            Matrix<double> x = operation.x;

            Vector<double> repetition_num = F_repetition_num(n1, n2);

            Matrix<double> diag_result = Matrix<double>.Build.DenseDiagonal(repetition_num.Count, 0);
            diag_result.SetDiagonal(repetition_num.PointwisePower(-1));

            return x * diag_result;
        }

        static Matrix<Complex> F_Hankel_inv(Matrix<Complex> L, int n_ori_row)
        {
            int n_row = L.RowCount; // get row 
            int n2 = L.ColumnCount; // get column
            int n1 = n_row / n_ori_row;  //the number of observation Vectors in each column

            //Multi-Threading -------------------------------------------
            MP_slice<Complex> operation = new MP_slice<Complex>(L, n_ori_row);
            operation.Perform();
            Matrix<Complex> x = operation.x;

            Vector<double> repetition_num = F_repetition_num(n1, n2);

            Matrix<double> diag_result = Matrix<double>.Build.DenseDiagonal(repetition_num.Count, 0);
            diag_result.SetDiagonal(repetition_num.PointwisePower(-1));

            return x * diag_result.ToComplex();
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
    }
    
    class MP_slice<T> where T : struct, IEquatable<T>, IFormattable
    {

        public Matrix<T> x;
        readonly Matrix<T> L;
        readonly int n1;
        readonly int n2;
        readonly int n_row;
        readonly int n_ori_row;

        public MP_slice(Matrix<T> L1, int na)
        {
            L = L1;
            n_ori_row = na;
            n_row = L.RowCount;
            n2 = L.ColumnCount;
            n1 = n_row / n_ori_row;

            x = Matrix<T>.Build.Dense(n_ori_row, n1 + n2 - 1);
        }

        void Slices(object data)
        {
            int i = (int)data;

            for (int r = 0; r < n1; r++)
            {
                if ((i + 1) + 1 - (r + 1) > 0 && (i + 1) + 1 - (r + 1) <= n2)
                {
                    int start = n_ori_row * (r) + 1;
                    int end = n_ori_row * (r + 1);
                    int length = end - start;
                    x.SetColumn(i,
                        x.Column(i) + L.Column((i - r),     //column 
                        n_ori_row * (r),                    //row n_ori_row * (r) + 1
                        length + 1));                       //length
                }
            }
        }

        public void Perform()
        {
            Thread[] allt = new Thread[n1 + n2 - 1];

            for (int i = 0; i < n1 + n2 - 1; i++)
            {
                Thread onestep = new Thread(Slices);
                onestep.Start(i);
                allt[i] = onestep;
            }

            for (int i = 0; i < n1 + n2 - 1; i++)
            {
                allt[i].Join();
            }
        }
    }
}
