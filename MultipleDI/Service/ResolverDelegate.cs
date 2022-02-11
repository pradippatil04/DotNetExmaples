using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultipleDI.Service
{
    public enum ServiceType
    {
        A,
        B,
        C
    }
    public delegate IService ServcieResolver(ServiceType serviceType);

}
