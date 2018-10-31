using System;

namespace method_monte_karlo
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 100000000;
            double x, y, z;
            double V = 72 * Math.Sqrt(10), Vd=0, I, Ir;

            Random rnd = new Random();
            functions F = new functions();

            for(int i=0; i<N; i++)
            {
                x = rnd.NextDouble();
                y = rnd.NextDouble();
                z = rnd.NextDouble();

                x = -3 + 6 * x;
                y = -3 + 6 * y;
                z = -Math.Sqrt(10) + 2 * Math.Sqrt(10) * z;

                if ( x*x+y*y<9 && Math.Abs(z)<Math.Sqrt(x*x+y*y+1))
                {
                    Vd = Vd + F.f(x, y, z);
                }
            }


            I = V * Vd / N;
            Ir = 4 * Math.PI * (250 * Math.Sqrt(10) + 2) / 15;

            Console.WriteLine("Методом Монте-Карло I = " + I );
            Console.WriteLine("Вычисление вручную  I = " + Ir);
            Console.ReadKey();
            

        }
    }


    class functions
    {
        public double f(double x, double y, double z) //функция под интегралом
        { return x*x+y*y+z; }

        
    }
}
