using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
 
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = 0, x2 = 1, m = 3,m1=0,m2=1, eps = 1.0e-7;
            int n = 0;

            Methods M = new Methods();
            M.Dichotomy(eps, x1, x2, ref m1, ref n);
            M.FixedPoint(eps, ref m2);
            M.Result();
           
            Console.ReadKey();
        }       
    }

    class Methods
    {
        Functions F = new Functions();
        public void Dichotomy(double eps, double x1, double x2,ref double m,ref int n)
        {
            while (eps < x2 - x1)
            {
                m = (x2 + x1) / 2;
                if (Math.Sign(f(x2)) == Math.Sign(f(m))) { x2 = m; } else { x1 = m; }
                n = n + 1;
            }
        }
        
        public void FixedPoint(double eps, ref double m)
        {
            while (Math.Abs(m - g(m)) > eps) { m = g(m); }}

        public void Result()
        {
            Console.WriteLine("Dichotomy: Корень  х = " + m1);
            Console.WriteLine("Fixedpoint: Корень  х = " + m2);
            Console.WriteLine("Число шагов = " + n);
            Console.WriteLine("Значение sin(x) " + Math.Sin(m));
            Console.WriteLine("Значение arccos(x) " + Math.Acos(m));
        }
    }

    class Functions
    {
        static double f(double x)
        { return Math.Sin(x) - Math.Acos(x); }
        static double g(double x)
        { return Math.Cos(Math.Sin(x)); }
    }
}

