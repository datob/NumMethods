using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main()
        {
            int n = 0;
            double x, y, x0=2, y0=10;
            double eps = 1.0E-12;

            Functions F=new Functions();

            while (Math.Sqrt(F.f(x0, y0) * F.f(x0, y0) + F.g(x0, y0) * F.g(x0, y0)) > eps)

            {
                x = x0 - 1 /
                    (F.fx(x0, y0) * F.gy(x0, y0) - F.fy(x0, y0) * F.gx(x0, y0)) * (F.gy(x0, y0) * F.f(x0, y0) - F.fy(x0, y0) * F.g(x0, y0));
                y = y0 - 1 /
                    (F.fx(x0, y0) * F.gy(x0, y0) - F.fy(x0, y0) * F.gx(x0, y0)) * (-F.gx(x0, y0) * F.f(x0, y0) + F.fx(x0, y0) * F.g(x0, y0));
                x0 = x; y0 = y;
                n = n + 1;

            }
            Console.WriteLine("x="+ x0 +", y=" + y0);
            Console.WriteLine();
            Console.WriteLine("количество шагов " + n);
            Console.ReadKey();
        }
        
    }
    class Functions 
    {
        public double f(double x, double y)
        { return x * x + 4 * y * y + 4 * x * y - 8 * x - 16 * y + 16; }
        public double g(double x, double y)
        { return x * x * x * x + 16 * y * y * y * y - 4 * x * y * y - 73; }
        public double fx(double x, double y)
        { return 2 * x + 4 * y - 8; }
        public double fy(double x, double y)
        { return 8 * y + 4 * x - 16; }
        public double gx(double x, double y)
        { return 4 * x * x * x - 4 * y * y; }
        public double gy(double x, double y)
        { return 64 * y * y * y - 8 * x * y; }
    }
}
