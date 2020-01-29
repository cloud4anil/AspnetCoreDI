using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreIoC.DbServices.Interface
{
    public interface ICustomerService
    {

        bool IsActiveCustomer();
    }
}
