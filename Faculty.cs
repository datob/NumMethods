using System;

class Program
{
    static void Main(string[] args)
    {
        Faculty M = new Faculty();
        M.students=400;
        M.computers=40;
        M.classrooms=33;
        M.class_area=2089;
        M.comp_norm=8;
        M.classrooms_norm=20;
        M.area_norm=5.3;
        M.Check();
     }
}

class  Faculty
{
    public int students, computers, classrooms;
    public double class_area;
    public int comp_norm, classrooms_norm;
    public double area_norm;

    public void Check()
    {
        int comp_index, classrooms_index;
        double area_index;

        comp_index=students/computers;
        classrooms_index=students/classrooms;
        area_index=class_area/students;

        if (comp_index<comp_norm) 
        {Console.WriteLine(" Компьютерный индекс в норме");}
        else
        {Console.WriteLine(" Число студентов на компьютер превышено");}
        Console.WriteLine(" comp_index = " + comp_index );
        Console.WriteLine();

        if (classrooms_index<classrooms_norm) 
        {Console.WriteLine(" Аудиторный индекс в норме");}
        else
        {Console.WriteLine(" Число студентов на аудиторию превышено");}
        Console.WriteLine(" classrooms_index = " + classrooms_index );
        Console.WriteLine();

        if (area_index>area_norm) 
        {Console.WriteLine(" Индекс площади в норме");}
        else
        {Console.WriteLine(" Индекс площади мал");}
        Console.WriteLine(" area_index = " + area_index );
        Console.WriteLine();
        Console.ReadKey();
    }
}
