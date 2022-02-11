using System;

namespace Base_Class
{

    public class Base
    {
        public Base()
        {
            Console.WriteLine("Base Constructor");
        }
        public void Print()
        {
            Console.WriteLine("Base Print");
        }
    }

    public class Derived : Base
    {
        public Derived()
        {
            Console.WriteLine("Derived Constructor");
        }

        public void Print()
        {
            Console.WriteLine("Derived Print");
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Base a = new Base();
            a.Print();

            Base b = new Derived();
            b.Print();

            // Derived c = new Base();
            Derived d = new Derived();
            d.Print();


            Console.ReadKey();
        }
    }
}
