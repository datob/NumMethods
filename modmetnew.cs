using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modmetodnewton
{
    class Program
    {
        static void Main()
        {
            int n = 0;
            double x0 = 1, y0 = 1;
            double eps = 1.0E-7;

            newton N = new newton();
            N.N2(eps, ref x0, ref y0, ref n);

            Console.WriteLine("x=" + x0 + ", y=" + y0);
            Console.WriteLine();
            Console.WriteLine("количество шагов " + n);
            Console.ReadKey();
        }

    }

    class newton
    {
        public void N2(double eps, ref double x0, ref double y0, ref int n)
        {
            double x, y;
            Functions F = new Functions();

            while ((F.f(x0, y0) * F.f(x0, y0) + F.g(x0, y0) * F.g(x0, y0)) > eps && n < 100)
            {
                x = x0 - 1 /
                    (F.fx(x0, y0) * F.gy(x0, y0) - F.fy(x0, y0) * F.gx(x0, y0)) * (F.gy(x0, y0) * F.f(x0, y0) - F.fy(x0, y0) * F.g(x0, y0));
                y = y0 - 1 /
                    (F.fx(x0, y0) * F.gy(x0, y0) - F.fy(x0, y0) * F.gx(x0, y0)) * (-F.gx(x0, y0) * F.f(x0, y0) + F.fx(x0, y0) * F.g(x0, y0));
                x0 = x; y0 = y;
                n = n + 1;

            }
            if (n == 100)
            {
                Console.WriteLine("Зацикливание !!");
                Console.ReadKey();

            }
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
