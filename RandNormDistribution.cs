using System;
namespace Modelling_p
{
    class Program
    {
        static void Main()
        {
            /*int N = 100000000; //Число испытаний
			double a = 1.0, D = 2.0; //Заданные матожидание и дисперсия
			double s, t; //Случайные величины с матожиданием a и дисперсией D
			double x, y; //Случайные величины из F.N_Standard(x,y) 			
            double Ms = 0, Ms2 = 0, Ds; //Находим: матожидания M[s] и M[s^2], дисперсию D[s]
            
			Random rnd = new Random();
			
			for (int i = 0; i < N; i++)
            {		
				x = rnd.NextDouble(); y = rnd.NextDouble(); 
				
				F.N_Standard(ref x, ref y);
				s = x * Math.Sqrt(D) + a; 
				t = y * Math.Sqrt(D) + a; 
				
                Ms = Ms + s + t; 
				Ms2 = Ms2 + s*s + t*t;				
            }			
			Ms = Ms/(2*N); Ms2 = Ms2/(2*N);
			Ds = Ms2 - Ms*Ms;
			*/


            /*int N = 100000000; //Число испытаний
            double a = 4.35;//Заданный параметр
            double x; //Случайная величина F.Exp_Standard(x,y) 			
            double Mx = 0, Mx2 = 0, Dx; //Находим: матожидания M[x] и M[x^2], дисперсию D[x]

            Random rnd = new Random();

            for (int i = 0; i < N; i++)
            {
                x = rnd.NextDouble();

                F.Exp_Standard(a, ref x);
                Mx = Mx + x;
                Mx2 = Mx2 + x * x;
            }
            Mx = Mx / N; Mx2 = Mx2 / N;
            Dx = Mx2 - Mx * Mx;
            */

            int N = 100000000; //Число испытаний
            double a = 4.35; //Заданный параметр
            double x; //Случайная величина F.Koshi_Standard(x,y) 			
            double Mx = 0, Mx2 = 0, Dx; //Находим: матожидания M[x] и M[x^2], дисперсию D[x]
            double alpha;

            Random rnd = new Random();

            for (int i = 0; i < N; i++)
            {
                x = rnd.NextDouble();
                alpha = rnd.NextDouble();

                F.Koshi_Standard(a,ref alpha, ref x);


                Mx = Mx + x;
                Mx2 = Mx2 + x*x;
            }
            Mx = Mx / N; Mx2 = Mx2 / N;
            Dx = Mx2 - Mx * Mx;


            Console.WriteLine();
            Console.Write("Mx = "); Console.Write("{0:f6}", Mx);
            Console.WriteLine();
            Console.Write("Ma = "); Console.Write("{0:f6}", 1.0 / a);
            Console.WriteLine();
            Console.WriteLine(); Console.WriteLine();
            Console.Write("Dx = "); Console.Write("{0:f6}", Dx);
            Console.WriteLine();
            Console.Write("Da = "); Console.Write("{0:f6}", 1.0 / (a * a));

            Console.ReadKey();
        }
    }

    class F //Modelling of Distributions 
    {
        public static void N_Standard(ref double x, ref double y)
        {// Modelling of the standard normal distribution						

            double z = x;
            x = Math.Sqrt(-2 * Math.Log(x)) * Math.Cos(2 * Math.PI * y);
            y = Math.Sqrt(-2 * Math.Log(z)) * Math.Sin(2 * Math.PI * y);
        }

        public static void Exp_Standard(double a, ref double x)
        {// Modelling of the standard exponential distribution					

            x = -Math.Log(x) / a;
        }

        public static void Koshi_Standard(double a,ref double alpha, ref double x)
        {// Modelling of the standard Koshi distribution					

            x = alpha*Math.Tan(Math.PI * x - Math.PI / 2) + a;
        }
    }
}
