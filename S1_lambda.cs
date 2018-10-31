using System;

/* Периодическая краевая задача на отрезке [0,2*Pi] 
 * для уравнения (p(x)y')'+(lambda-q(x))y=0
 * с граничными условиями
 * y(0) = 1 = y(2*Pi),   y'(0) = y'(2*Pi)
 */

 /*#########    ПРОВЕРКА АЛГОРИТМА    #########*/
 
/* На отрезке [0,2*Pi] решаем краевую задачу 
 * для уравнения Матье с параметром 1:
 * y"+(lambda-2*cos(2*x))*y=0, 
 * y(0) = 1 = y(2*Pi),   y'(0) = y'(2*Pi) 
 */

namespace S1_lambda
{
    class Program
    {
        static void Main(string[] args)
        {
			int N = 1000;
			double h = 2*Math.PI/N;
			double x0 = 0.0, y0 = 1.0, y1 = 0.0; 
			//double x0=0.0, y0=0.0, y1 = 1.0;
            //Minimum M = new Minimum();
			RK_Adams RKA = new RK_Adams();			
			
			double lambda = - 1.0, H = 0.01; 
			int L = 200;
			double u = y0, v = y1;
			double left = 0.0, middle = 0.0, right = 0.0;
			for(int k = 0; k < L; k++)
			{				
				left = middle; middle = right;
				double u_left = u, v_left = v;
				RKA.shot( N, h, lambda, x0, ref u, ref v );
				right = F.eps( u_left, v_left, u, v );
				
				if( left > middle && middle < right )
				{
					Console.WriteLine( (lambda - H) + " " 
					+ left + " " + middle + " " + right);
				}				 
				
				lambda = lambda + H;
			}
			
			Console.ReadKey();
        }				
    }
 
	public class Minimum
	{
	   public void Min1(ref double x)
	   {
	   
	   }
	   
	   public void Min2(ref double x, ref double t)
	   {	   
	   }
	}
 
    public class F
    {        
		static double p(double x) { return 1; }
		static double q(double x) { return 2*Math.Cos(2*x); }
		static double dp(double x) { return 0; }
		
		public static double uf(double x, double lambda, double u, double v) 
		{ return v; }
		public static double vf(double x, double lambda, double u, double v) 
		{ return ( (q(x)-lambda)*u - dp(x)*v ) / p(x); }		
		
		public static double eps(double y0, double y, double dy, double dy0)
		{return (y0-y)*(y0-y)+(dy0-dy)*(dy0-dy) ;}
    }

    public class RK_Adams
    {
        //Методом RK4 решаем систему u' = uf(x,u,v), v' = vf(x,u,v), x in [x0, x0+N*h]
		public void shot
		(int N, double h, double lambda, double x0, ref double u, ref double v)
        {
			double x = x0;
            double u1, u2, u3, u4;             // Коэффициенты RK4 для функции u(x)
            double v1, v2, v3, v4;             // Коэффициенты RK4 для функции v(x)
            for (int i = 0; i < N; i++)        // Цикл-выстрел метода RK4
            {
                u1 = h * F.uf(x, lambda, u, v);
                v1 = h * F.vf(x, lambda, u, v);

                u2 = h * F.uf(x + h / 2.0, lambda, u + u1 / 2.0, v + v1 / 2.0);
                v2 = h * F.vf(x + h / 2.0, lambda, u + u1 / 2.0, v + v1 / 2.0);

                u3 = h * F.uf(x + h / 2.0, lambda, u + u2 / 2.0, v + v2 / 2.0);
                v3 = h * F.vf(x + h / 2.0, lambda, u + u2 / 2.0, v + v2 / 2.0);

                u4 = h * F.uf(x + h, lambda, u + u3, v + v3);
                v4 = h * F.vf(x + h, lambda, u + u3, v + v3);

                u = u + (u1 + 2.0 * u2 + 2.0 * u3 + u4) / 6.0;
                v = v + (v1 + 2.0 * v2 + 2.0 * v3 + v4) / 6.0;

                x = x + h;
            } // Конец цикла-выстрела
        }     // Конец метода 'shot'

        public void Adams
        (int N, double h, double x0, ref double u, ref double v)
        {
        }
    }	
}
