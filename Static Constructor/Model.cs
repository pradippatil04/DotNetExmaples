using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static_Constructor
{
    public class Model
    {
        private static bool isChnaged;
        private static int myVar;
        public static int pubStatField = 5;
        public int MyProperty
        {
            get
            {
                if (!isChnaged)
                {
                    myVar = 5;
                    isChnaged = true;
                }
                return myVar;
            }
           
        }

        public Model()
        {

        }

        static Model()
        {
            Console.WriteLine("static construcotr called");
        }
        public void AccessVar()
        {
            Console.WriteLine($"var value {MyProperty} and change status :{isChnaged}");
        }
    }
}
