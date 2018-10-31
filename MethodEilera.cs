using System;

namespace Method_Elira
{
    public class Program
    {
        static void Main()
        {
            int k;
            int N = 200; // разбиение сетки
            double a = 0; // начало отрезка
            double b = 2; // конец отрезка
            double[] x = new double[N]; // массив для узлов сетки
            double[] Uob = new double[N]; // массив для u(xk) обычного метода Эйлера
            double[] Vob = new double[N]; // массив для v(xk) обычного метода Эйлера
            double[] Umod = new double[N]; // массив для u(xk) модифицир. метода Эйлера
            double[] Vmod = new double[N]; // массив для v(xk) модифиц. метода Эйлера
            double[] Ureal = new double[N]; // массив для u(xk) аналитически
            double[] Vreal = new double[N]; // массив для v(xk) аналитически

            double h = (b - a) / N; // шаг сетки
            double du, dv;

            Euler_du_dv E = new Euler_du_dv();

            x[0] = a;
            Uob[0] = 0;
            Vob[0] = 1;
            Umod[0] = 0;
            Vmod[0] = 1;
            Ureal[0] = 0;
            Vreal[0] = 1;

            for (k = 1; k < N; k++)
            {
                x[k] = x[k - 1] + h;

                E.EulerOrb(out du, out dv, x[k - 1], Uob[k - 1], Vob[k - 1], h);
                Uob[k] = Uob[k - 1] + du;
                Vob[k] = Vob[k - 1] + dv;

                E.EulerMod(out du, out dv, x[k - 1], Umod[k - 1], Vmod[k - 1], h);
                Umod[k] = Umod[k - 1] + du;
                Vmod[k] = Vmod[k - 1] + dv;

                Ureal[k] = (Math.Exp(2 * x[k - 1])) * Math.Sin(x[k - 1]);
                Vreal[k] = 2 * Ureal[k - 1] + (Math.Exp(2 * x[k - 1])) * Math.Cos(x[k - 1]);

            }

            for (k = 0; k < N; k++)
            {
                if (k % 20 == 0)
                    Console.WriteLine("  Uob = " + Uob[k] + "  Umod = " + Umod[k] + "  Ureal = " + Ureal[k]); // печать функции u посчитанную обычным методом Эйлера, модифиц. и аналитически

            }

            Console.WriteLine();
            Console.WriteLine();
            for (k = 0; k < N; k++)
            {
                if (k % 20 == 0)
                    Console.WriteLine("  Vob = " + Vob[k] + "  Vmod = " + Vmod[k] + "  Vreal = " + Vreal[k]); // печать функции v посчитанную обычным методом Эйлера, модифиц. и аналитически

            }
            Console.ReadKey();
        }
    }

    class functions
    {
        public static double f(double x, double u, double v)
        { return v; }
        public static double g(double x, double u, double v)
        { return 2 * v - u + 2 * Math.Exp(2 * x) * Math.Cos(x); }
    }

    class Euler_du_dv
    {
        public void EulerOrb(out double du, out double dv, double x, double u, double v, double h)
        {
            du = h * functions.f(x, u, v);
            dv = h * functions.g(x, u, v);

        }

        public void EulerMod(out double du, out double dv, double x, double u, double v, double h)
        {
            du = h * functions.f(x + h / 2, u + (h / 2) * functions.f(x, u, v), v + (h / 2) * functions.g(x, u, v));
            dv = h * functions.g(x + h / 2, u + (h / 2) * functions.f(x, u, v), v + (h / 2) * functions.g(x, u, v));

        }
    }

}
