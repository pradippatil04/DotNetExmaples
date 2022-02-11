using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static_Constructor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Model.pubStatField);
            Model m1 = new Model();
            m1.AccessVar();

            Model m2 = new Model();
            m2.AccessVar();
            Model m3 = new Model();
            m3.AccessVar();
            Console.ReadLine();
        }
    }
}
