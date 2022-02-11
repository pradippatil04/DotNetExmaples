using System;
using System.Linq;
using System.Collections.Generic;

namespace StaticExample
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = new List<int> { 2, 4, 5 };

            int[] arr = { 2, 34,2,4,5,2 };
            arr.Where(x => x % 2 == 0).Sum(s=> s+1);

            var res = arr.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Distinct());

            //foreach (var item in res)
            //{
            //    Console.WriteLine(item.Key);

            //    foreach (var v in item)
            //    {

            //    }
            //}

            nums.RemoveAll(x=>x > 0);

            A a = new A();
            int one = 5;
            int two = 5;
            Console.WriteLine(a.Sub(ref one,out two));
            Console.ReadKey();
        }
    }

    public interface ITest
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
       
    }

    public class A //:ITest
    {
        public int Sub(ref int a, out int b)
        {
            b = 0;
            return 0;
        }

       public string Sub(out int a, int b)
        {
            a = "";
            return "";
        }
    }

}
