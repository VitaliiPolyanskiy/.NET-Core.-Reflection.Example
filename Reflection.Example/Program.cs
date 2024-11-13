using System;
using System.Reflection;

abstract class Figure
{
    public double x;
    public double y;
    public void SetDimension(double i, double j)
    {
        x = i;
        y = j;
    }
    public abstract void ShowSquare();
}

class Triangle : Figure
{
    public override void ShowSquare()
    {
        Console.WriteLine("\nSquare of triangle: {0}", x * 0.5 * y);
    }
}

class Rectangle : Figure
{
    public override void ShowSquare()
    {
        Console.WriteLine("\nSquare of rectangle: {0}", x * y);
    }
}

class Circle : Figure
{
    public override void ShowSquare()
    {
        Console.WriteLine("\nSquare of circle: {0}", 3.14 * x * x);
    }
}

class Student : IComparable
{
    int age;
    string name;
    string surname;
    double avg;

    static int counter = 0;
    public Student()
    {
        this.Code = ++counter;
    }

    public int CompareTo(object obj)
    {
        Student r = (Student)obj;
        return name.CompareTo(r.name);
    }

    public int Age
    {
        get
        {
            return age;
        }
        set
        {
            if (value > 0)
                age = value;
        }
    }

    public int Code { get; }

    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            if (value != "")
                name = value;
        }
    }

    public string Surname
    {
        get
        {
            return surname;
        }
        set
        {
            if (value != "")
                surname = value;
        }
    }

    public double Average
    {
        get
        {
            return avg;
        }
        set
        {
            if (value >= 0 && value <= 12)
                avg = value;
        }
    }
    public string Phone { get; set; }
}
public record Team(string Name, string City);
public record struct Person(string Name);

class EntryPoint
{
    enum Day_Of_Week { Sunday, Monday, Thuesday, Wednesday, Thursday, Friday, Saturday };

    static void Info(Type t)
    {
        Console.WriteLine("\n----------Тип " + t.FullName);
        if (t.IsAbstract)
            Console.WriteLine("Абстрактный класс");
        else if (t.IsClass)
            Console.WriteLine("Обычный класс");
        else if (t.IsEnum)
            Console.WriteLine("Перечисление");
        else if (t.IsValueType)
            Console.WriteLine("Структура");

        Console.WriteLine("Базовый класс " + t.BaseType);

        Console.WriteLine("\nЧлены класса:\n ");
        foreach (MemberInfo mi in t.GetMembers())
        {
            Console.WriteLine(mi.DeclaringType + " " + mi.MemberType + " " + mi.Name);
        }
        MethodInfo[] met = t.GetMethods();
        foreach (MethodInfo m in met)
        {
            Console.WriteLine("\nМетод: " + m);
            ParameterInfo[] pi = m.GetParameters();
            if (pi.Length > 0)
                Console.WriteLine("Параметры: ");
            foreach (ParameterInfo p in pi)
                Console.WriteLine(p);
        }
        FieldInfo[] fi = t.GetFields();
        if (fi.Length > 0)
            Console.WriteLine("\nПоля: ");
        foreach (FieldInfo f in fi)
            Console.WriteLine(f);

        PropertyInfo[] pr = t.GetProperties();
        if (pr.Length > 0)
            Console.WriteLine("\nСвойства:");
        foreach (PropertyInfo prop in pr)
        {
            Console.WriteLine("{0} {1}", prop.PropertyType, prop.Name);
        }

        Type[] ii = t.GetInterfaces();
        if (ii.Length > 0)
            Console.WriteLine("\nРеализованные интерфейсы:");
        foreach (Type i in ii)
        {
            Console.WriteLine(i.Name);
        }
        Console.ReadLine();
    }

    static void Main()
    {
        Type t = typeof(Team);
        Info(t);
        t = typeof(Person);
        Info(t);
        var student = (Name: "Ivan", Surname: "Ivanov", Age: 25, Rating: 11.5);
        t = student.GetType();
        Info(t);
        // Рефлексия представляет собой процесс выявления типов во время выполнения приложения (Run-Time).
        // Класс System.Type представляет изучаемый тип, инкапсулируя всю информацию о нем.
        t = typeof(Figure);
        Info(t);
        Figure f = new Triangle();
        t = f.GetType();
        Info(t);
        f = new Circle();
        t = f.GetType();
        Info(t);
        Type myType = Type.GetType("rectangle",
            false /* исключение не будет генерироваться, если класс не удастся найти */,
            true /* регистр не учитывается в первом параметре */);
        Info(myType);
        Student st = new Student();
        t = st.GetType();
        Info(t);
        t = typeof(Day_Of_Week);
        Info(t);
        t = typeof(int);
        Info(t);
        t = Type.GetType("System.Collections.Generic.List`1");
        Info(t);
    }
}
