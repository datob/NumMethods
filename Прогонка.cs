using System;

namespace Kraevae_zadacha.Progonka
{
    class Program
    {
        static void Main(string[] args)
        {
            int m;
            
            double h = 0.01; //шаг сетки
            int N = 100;

            double[] y = new double[N]; // массив для к-ф b
         
          
            

           
            Console.WriteLine();
            Console.ReadKey();
            //a[N] = -F.v;
            //c[0] = -F.j;

        }
    }

    class BoundaryProblem
    {
        public void Gauss3(double h, int N, out double[] y)
        {
            int n;
            double c, a, x=0;

            double[] f = new double[N]; // массив для свободного столбца
            f[0] = h * F.k;
            f[N] = h * F.w;

            double[] b = new double[N]; // массив для к-ф b
            b[0] = h * F.i + F.j;
            b[N] = h * F.u + F.v;

            for (n = 1; n <= N; n++) // прямой ход метода Гаусса
            {
                x=x+h;
                c = 1 + F.p(x) * h / 2;
                a = 1 - F.p(x) * h / 2;

                b[n] = b[n] - c * a / b[n - 1];
                f[n] = f[n] - f[n - 1] * a / b[n - 1];
            }

            for (n = N;  ; n--) //обратный ход метода Гаусса
            {
                x = x - h;
                c = 1 + F.p(x) * h / 2;

                f[n-1]=f[n-1]-f[n]*c/b[n];
                y[n]=f[n]/b[n];
            }
            y[0] = f[0] / b[0];
        }
    }
            
   public class F
    {
        public static double i = 0, j = -1, k = 0;
        public static double u = 3, v = 1, w = -2;
        public static double p(double x) //функция при первой производной
        { return -2 * x; }
        public static double q(double x) //функция при первой у
        { return -4; }
        public static double r(double x) //функция cвободная
        { return 6 * x; }

    }

    /* Задача словами
    * Краевая задача на отрезке [x(0),x(N)]
    * с шагом h и сеткой с узлами x(n), n = 0,1, ... ,N
    * y" + p(x)*y' + q(x)*y = r(x),
    * 
    *  Смешанные условия:
    * i*y(0) - j*y'(0) = k, u*y(N) + v*y'(N) = w,
    * i*j >= 0, |i| + |j| > 0, u*v >= 0, |u| + |v| > 0
    * 
    *
    * Аппроксимация производных:
    * y'(n) = (y(n+1)-y(n-1))/(2*h)
    * y"(n) = (y(n+1)-2*y(n)+y(n-1))/h^2
    * 
    *
    * В узлах n = 1,2, ... ,N-1 уравнение принимает вид
    * a(n)*y(n-1) + b(n)*y(n) + c(n)*y(n+1) = f(n), где
    * a(n) = 1 - p(n)*h/2,   b(n) = q(n)*h^2 - 2,
    * c(n) = 1 + p(n)*h/2,   f(n) = r(n)*h^2
    * 
    * 
    * В узлах n = 0, N аппрксимируем y' с точностью h:
    * y'(0) = (y(1)-y(0))/h,  y'(N) = (y(N)-y(N-1))/h
    * Граничные условия примут вид
    * b(0)*y(0) + c(0)*y(1) = f(0),
    * a(N)*y(N-1) + b(N)*y(N) = f(N),
    * b(0) = h*i + j,  c(0) = -j,  f(0) = h*k
    * a(N) = -v,  b(N) = h*u+v,  f(N) = h*w
    *
    * 
    * Матрица системы уравнений:
    * | b(0) c(0)                                        | f(0) |
    * | a(1) b(1) c(1)                                   | f(1) |
    * |      a(2) b(2) c(2)                              | f(2) | 
    * | -------------------------------------------------| ---- |
    * | -------------------------------------------------| ---- |
    * | -------------------------------------------------| ---- |
    * |                       a(N-2) b(N-2) c(N-2)       |f(N-2)|
    * |                              a(N-1) b(N-1) c(N-1)|f(N-1)|
    * |                                     a(N)   b(N)  | f(N) |
    * 
    * 
    * Прямой ход:
    * b(n) = b(n) - c(n-1)*a(n)/b(n-1);  
    * f(n) = f(n) - f(n-1)*a(n)/b(n-1); 
    * n = 1,2, ... ,N-1
    *   
    * 
    * Обратный ход:
    * f(n-1) = f(n-1) - f(n)*c(n-1)/b(n);
    * y(n)=f(n)/b(n);
    * n = N,N-1, ... ,1
    * y(0) = f(0)/b(0);
    * 
    */
}
