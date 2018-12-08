using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 

	namespace ConsoleApplication7 
{ 
	class Program 
{ 
	static void Main(string[] args) 
{ 

	int n = 50; 
	int[] C = new int[n+1];
	Random rand = new Random();
	for (int i = 0; i < C.Length; i++)
	{C[i] = rand.Next(1,50);
	Console.Write(" "+C[i]);
}
	Console.WriteLine(); 


	Vector vec = new Vector(); 
	vec.Inversion(n, ref C); 
	int max = vec.Max(C);

	for (int i = 0; i < n + 1; i++) 
	{ 
	Console.Write(" " + C[i]); 
	} 
	
	//Console.ReadKey(); 
  	Console.WriteLine(); 
	Console.Write(" MaxM = " +max); 
} 
} 



class Vector 
{ 
	public void Inversion(int n,ref int[] C) 
{ 

	int[] L = new int[n + 1]; 
	for (int i =0; i < n + 1; i++) { L[i] = C[n - i]; } 
	for (int i = 0; i < n + 1; i++) { C[i] = L[i]; } 
} 

 	public int Max(int[] array)       // функция Max которая будет искать максимальный элемент - Int перед названием означает, что функция в качестве результата вернет целочисленное значение - в параметрах передаем массив
        {
        int max = array[0];        // присваиваем переменной max значение первого элемента массива  
        for (int i = 0; i < array.Count(); i++) // делам цикл перебора всех элементов массива
            {
                if (max < array[i])    // если текущий элемент больше переменной max
                {
                max = array[i];  // присваиваем переменной max значение текущего элемента
                }
            }
                return max;    // возвращаем значение max
        }
} 
}
