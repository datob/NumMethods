using System;

namespace methodminqwadrat
{
    class Program
    {
        static void Main(string[] args)
        {
            double Sxx=0, Sx=0, Sy=0, Sxy=0, a, b;
            int N=5;
            double[] x = new double [5] {0.1, 0.5, 0.9, 1.6, 2.1};
            double[] y = new double [5] {4.1, 3.1, 1.8, 0.95, -0.1};
           
            
             for (int i=0;i<N;i++)
              {
              Sxx = Sxx + x[i]*x[i];
              Sx = Sx + x[i];
              Sxy = Sxy + x[i] * y[i];
              Sy = Sy + y[i];
              }

             a = (Sxy * N - Sx * Sy) / (Sxx * N - Sx * Sx);
             b = (Sxx * Sy - Sxy * Sx) / (Sxx * N - Sx * Sx);


             Console.WriteLine( " a = " + a );
             Console.WriteLine(" b = " + b);
             Console.ReadKey();
         }      

    }
 

}
