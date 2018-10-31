using System;

class Program
{
    static void Main(string[] args)
    {
        Faculty M = new Faculty();
        int s = 400, c = 40, c1 = 33, c_norm = 8, c1_norm = 20;
        double a = 2012, a_norm = 5.3;
        M.Check(s,c,c1,a , c_norm, c1_norm,a_norm);
    }
}

class Faculty
{        public void Check(int students,ref int computers,ref int classrooms,int comp_norm,int classrooms_norm,double area_norm,ref double class_area)
    {
        int comp_index, classrooms_index;
        double area_index;

        comp_index = students / computers;
        classrooms_index = students / classrooms;
        area_index = class_area / students;

        if (comp_index < comp_norm)
        { Console.WriteLine(" Компьютерный индекс в норме"); }
        else
        { Console.WriteLine(" Число студентов на компьютер превышено"); }
        Console.WriteLine(" comp_index = " + comp_index);
        Console.WriteLine();

        if (classrooms_index < classrooms_norm)
        { Console.WriteLine(" Аудиторный индекс в норме"); }
        else
        { Console.WriteLine(" Число студентов на аудиторию превышено"); }
        Console.WriteLine(" classrooms_index = " + classrooms_index);
        Console.WriteLine();

        if (area_index > area_norm)
        { Console.WriteLine(" Индекс площади в норме"); }
        else
        { Console.WriteLine(" Индекс площади мал"); }
        Console.WriteLine(" area_index = " + area_index);
        Console.WriteLine();
        Console.ReadKey();

        computers = students / comp_norm;
        classrooms = students / classrooms_norm;


    }
}
