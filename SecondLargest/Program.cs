using System;

namespace SecondLargest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var result = secondLargest(1, 8, 6, 4,3,1);
            Console.WriteLine("result : {0}",result);
            Console.ReadLine();
        }


        static int secondLargest(params int [] number)
        {
            int largest = int.MinValue;
            int secondLargest = int.MinValue;

            for (int i = 0; i < number.Length; i++)
            {
                if(number[i] > largest)
                {
                    secondLargest = largest;
                    largest = number[i];
                }
                else if(number[i] < largest && number[i] > secondLargest)
                {
                    secondLargest = number[i];
                }

            }
            return secondLargest;
        }
    }
}
