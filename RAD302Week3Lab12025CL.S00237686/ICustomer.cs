using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAD302Week3Lab12025CL.S00237686
{
    public interface ICustomer<T> : IRepository<T> where T : Customer
    {
    }
}
