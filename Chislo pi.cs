using System;

namespace ConsoleApplication1
{
    class ChisloPi
    {
        static void Main(string[] args)
        {
            int N = 1000000, Nd = 0;
            double  x, y, x0=0.5, y0=0.5, P;


            Random rnd = new Random();

            for (int i = 0; i < N; i++)
            {
                x=rnd.NextDouble();
                y=rnd.NextDouble();
                if ((x0-x)*(x0-x)+(y-y0)*(y-y0)<0.25) { Nd = Nd + 1; }
            }

            P = 4 *(double) Nd / N;

            Console.WriteLine("Число п = " + P);
            Console.ReadKey();
        }
    }
}
