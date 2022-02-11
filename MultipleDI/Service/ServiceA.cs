using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultipleDI.Service
{
    public class ServiceA : IService
    {
        public string GetFrom()
        {
            return "From A";
        }
    }
}
