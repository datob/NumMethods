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
            double a = 0, b = 1, m = 0, eps = 1.0e-12;
            int n = 0;
            while (eps < b - a)
            {
                m = (b + a) / 2;
                if (Math.Sign(f(b)) == Math.Sign(f(m))) { b = m; }
                else { a = m; }
                n = n + 1;

            }


            Console.WriteLine("Кореь уравнения х = " + m);
            Console.WriteLine("Число шагов = " + n);
            Console.WriteLine("Значение sin(x) "    + Math.Sin(m));
            Console.WriteLine("Значение arccos(x) " + Math.Acos(m));
            Console.ReadKey();
        }

        static double f(double x)
        {
            return Math.Sin(x) - Math.Acos(x);
        }

    }
}
