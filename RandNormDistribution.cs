using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 

namespace Modelling_P 
{ 
class Program 
{ 
static void Main(string[] args) 
{ 
int N = 1000000; 
double D = 2.0; 
double a = 1.0; 
double x, y; 
double s, t; 
double Ms=0, Ms2=0, Ds; 

Random rnd = new Random(); 

for (int i = 0; i < N; i++) 
{ 
x = rnd.NextDouble(); 
y = rnd.NextDouble(); 

F.N_Standart(ref x, ref y); 

s = x * Math.Sqrt(D) + a; 
t = y * Math.Sqrt(D) + a; 

Ms = Ms + s + t; 
Ms2 = Ms2 + s * s + t * t; 

//Console.WriteLine("Ms[" + i + "] = " + Ms); 
//Console.WriteLine("Ms2[" + i + "] = " + Ms2); 
} 
Ms = Ms / (2 * N); 
Ms2 = Ms2 / (2 * N); 
Ds = Ms2 - Ms*Ms; 
Console.Write("Ms = " ); Console.Write("{0:f5}", Ms); 
Console.WriteLine(); 
//Console.WriteLine("Ms2 = " + Ms2); 
Console.Write("Ds = "); Console.Write("{0:f5}", Ds); 
//Console.ReadKey(); 

} 
} 
class F 
{ 
public static void N_Standart(ref double x, ref double y) 
{ 
double z = x; 
x = Math.Sqrt(-2 * Math.Log(x)) * Math.Cos(2 * Math.PI * y); 
y = Math.Sqrt(-2 * Math.Log(z)) * Math.Sin(2 * Math.PI * y) ; 

} 
} 
}