using System;

/* Краевая задача на отрезке [x(0),x(N)] 
 * с сеткой из N узлов x(n), n=0,1,...,N с шагом h
 *
 * для уравнения y"+p(x)y'+q(x)y=r(x)
 *
 * с граничными условиями
 * i*y(0)-j*y'(0)=k,   u*y(N)+v*y'(N)=w, 
 * где |i|+|j| > 0,  |v|+|u| > 0
 *  
 * Аппроксимация производных:
 * y'(n)=[y(n+1)-y(n-1)]/(2h), y"(n)=[y(n+1)-2y(n)+y(n-1)]/h^2.
 *
 * В узлах сетки с номерами n = 1,...,N-1 уравнение имеет вид 
 * a(n)*y(n-1)+b(n)*y(n)+c(n)*y(n+1) = f(n), 
 * где
 * a(n)=1-h*p(n)/2, b(n)=h^2*q(n)-2, 
 * c(n)=1+h*p(n)/2, f(n)=h^2*r(n).
 *
 * В узлах сетки n = 0 и n=N-1 аппроксимируем производные:
 * y'(0)=[y(1)-y(0)]/h,  y'(N)=[y(N)-y(N-1)]/h.
 * Граничные условия примут вид
 * b(0)*y(0)+c(0)*y(1)=f(0),   b(0)=i*h+j, c(0)=-j, f(0)=k*h,
 * a(N)*y(N-1)+b(N)*y(N)=f(N), a(N)=-v, b(N)=u*h+v, f(N)=w*h.
 * 
 * 
 * Матрица системы уравнений принимает вид
 * |b(0) c(0) . . . . . . . . . . . . . . . . . . . . . . | f(0) |
 * |a(1) b(1) c(1). . . . . . . . . . . . . . . . . . . . | f(1) |
 * |. .  a(2) b(2) c(2) . . . . . . . . . . . . . . . . . | f(2) |
 * |------------------------------------------------------|------|
 * |------------------------------------------------------|------|
 * |------------------------------------------------------|------|
 * |. . . . . . . . . . . . .  a(N-2) b(N-2) c(N-2) . . . |f(N-2)|
 * |. . . . . . . . . . . . . . . . . a(N-1) b(N-1) c(N-1)|f(N-1)|
 * |. . . . . . . . . . . . . . . . . . . . . a(N)   b(N) | f(N) |
 * 
 * Проход сверху вниз (n = 1,...,N-1):
 * b(n)=b(n)-c(n-1)*a(n)/b(n-1), 
 * f(n)=f(n)-f(n-1)*a(n)/b(n-1).
 * Дополнительно задаем a(N)=-v и вычисляем
 * b(N)=b(N)-c(N-1)*a(N)/b(N-1), 
 * f(N)=f(N)-f(N-1)*a(N)/b(N-1).
 * 
 * Проход снизу вверх (n = N-1,...,0):
 * f(n)=f(n)-f(n+1)*c(n)/b(n+1),
 * y(n+1)=f(n+1)/b(n+1).
 * Дополнительно находим y(0)=f(0)/b(0).
 */

/*#########    ПРОВЕРКА АЛГОРИТМА    #########*/

/* На отрезке [0,1] решаем краевую задачу 
 * y"+2xy'+2y=4x, y(0)=1, y(1)=1+1/e.
 * Точное решение y=x+exp(-x^2). 
 * 
 * Здесь i=1, j=0, k=1,  u=1, v=0, w=1+1/e, поэтому
 * b(0)=h, c(0)=0, f(0)=h ,
 * a(N)=0, b(N)=h, f(N)=(1+1/e)*h .
 * 
 */

namespace boundary
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 100000;                 //N - число шагов
            double x0 = 0.0, xN = 1.0;   //[x0,xN] - отрезок
            double h = (xN - x0) / N;    // шаг            

            double[] x = new double[N + 1]; x[0] = x0;
            double[] y;
            //double[] y = new double[N + 1];

            BoundaryProblem BP = new BoundaryProblem();
            BP.Gauss3(x0, h, N, out y);

            Console.WriteLine(" x = " + x[0] + ", y = " + y[0]);
            Console.WriteLine(" Точное значение: " + exact(x[0]));
            Console.WriteLine();

            // Заполнение значений X (в узлах сетки), диагоналей A, B, C и столбца F
            for (int n = 1; n <= N; n++)
            {
                x[n] = x[n - 1] + h;
                if (n % 10000 == 0)
                {
                    Console.WriteLine(" x = " + Math.Round(x[n], 2) + " ,  y = " + y[n]);
                    Console.WriteLine(" Точн. реш. y = " + exact(x[n]));
                    Console.WriteLine();
                }
            }

            Console.ReadKey();
        }

        static double exact(double x) { return x * Math.Exp(x * x) - x; }
    }

    public class F
    {
        public static double i = 0, j = -1, k = 0;
        public static double u = 3, v = -1, w = -2;

        public static double p(double x) { return -2 * x; }
        public static double q(double x) { return -4; }
        public static double r(double x) { return 6 * x; }
    }

    public class BoundaryProblem
    {
        public void Gauss3
        (double x0, double h, int N, out double[] b)
        {
            double a;               // Имитация массива a(1)...a(N)
            b = new double[N + 1];  // Инициируем массив b(0)...b(N)
            b[0] = F.i * h + F.j;   // Задаем b(0)

            double x = x0;
            double[] f = new double[N + 1]; f[0] = F.k * h;
            double[] c = new double[N]; c[0] = -F.j;

            // Цикл сверху-вниз: c(0), b(0), f(0) заданы выше
            for (int n = 1; n < N; n++)
            {
                x = x + h;
                a = 1 - h * F.p(x) / 2;

                b[n] = h * h * F.q(x) - 2;
                b[n] = b[n] - c[n - 1] * a / b[n - 1];

                f[n] = h * h * F.r(x);
                f[n] = f[n] - f[n - 1] * a / b[n - 1];

                c[n] = 1 + h * F.p(x) / 2; // Это c(n) для шага n+1                  
            }

            // На шаге N дополнительно задаем a(N), b(N), f(N) 
            a = -F.v; b[N] = F.u * h + F.v; f[N] = F.w * h;
            b[N] = b[N] - c[N - 1] * a / b[N - 1];
            f[N] = f[N] - f[N - 1] * a / b[N - 1];

            // Цикл снизу-вверх: на входе c(N-1) определено
            for (int n = N - 1; n >= 0; n--)
            {
                f[n] = f[n] - f[n + 1] * c[n] / b[n + 1];
                b[n + 1] = f[n + 1] / b[n + 1];
            }

            b[0] = f[0] / b[0];
        }
    }
}
