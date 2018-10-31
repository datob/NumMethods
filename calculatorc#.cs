using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select an action : addition, subtraction, multiplication, division");
            Console.Write("action = ");
            string str = Console.ReadLine();
            if (str == "addition")
            {
                do
                {
                    Console.Write("x = ");
                    int x = Convert.ToInt32(Console.ReadLine());

                    Console.Write("y = ");
                    int y = Convert.ToInt32(Console.ReadLine());

                    int sum = x + y;
                    Console.WriteLine("Result: {0}", sum);
                }
                while (true);
            }
            else if (str == "subtraction")
            {
                do
                {
                    Console.Write("x = ");
                    int x = Convert.ToInt32(Console.ReadLine());

                    Console.Write("y = ");
                    int y = Convert.ToInt32(Console.ReadLine());

                    int sum = x - y;
                    Console.WriteLine("Result: {0}", sum);
                }
                while (true);
            }
            else if (str == "multiplication")
            {
                do
                {
                    Console.Write("x = ");
                    int x = Convert.ToInt32(Console.ReadLine());

                    Console.Write("y = ");
                    int y = Convert.ToInt32(Console.ReadLine());

                    int sum = x * y;
                    Console.WriteLine("Result: {0}", sum);
                }
                while (true);
            }
            else if (str == "division")
            {
                do
                {
                    Console.Write("x = ");
                    int x = Convert.ToInt32(Console.ReadLine());

                    Console.Write("y = ");
                    int y = Convert.ToInt32(Console.ReadLine());

                    int sum = x / y;
                    Console.WriteLine("Result: {0}", sum);
                }
                while (true);
            }

            else if (str == "exit")
            { Environment.Exit(0); }
            else
            {
                Console.WriteLine("good bye");
                   }
            
        }
    }
}
