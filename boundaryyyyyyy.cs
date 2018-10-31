using System;

namespace Metodprogonki

{
   public class Program
    {
        static void Main(string[] args)
        {   int N = 100;
            double h = 0.01;
            double[] x = new double[N];
            double[] a = new double[N];
            double[] b = new double[N];
            double[] c = new double[N];
            double[] f = new double[N];
            functions F = new functions();
            b[0]=h*F.i+F.j;
            f[0]=h*F.j;
            b[N]=h*F.u+F.v;
            f[N]=h*F.w;






        }
  class boundaryproblem
  {
      public void gauss3(double h,int N,out double[]y;)
      double x;
      double[]y = new double[N];
      double[]f = new double[N];
  }
        
        
 class functions
        {
     public double i = 0, j = -1,k = 0; 
     public double u = 3,v = 1,w = -2;
     public static double p(double x){ return -2*x; }
     public static double q(double x){ return -4; }
     public static double r(double x){ return 6*x; }
 }
    
    
    }
}
