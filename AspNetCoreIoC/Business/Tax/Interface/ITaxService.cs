using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreIoC.Business.Tax.Interface
{
    public interface ITaxService
    {
        int CalculatedTax();
    }
}
