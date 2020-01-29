using AspNetCoreIoC.Business.Tax.Interface;


namespace AspNetCoreIoC.Business.Tax.Implementation
{
    public class IndiaTaxService : ITaxService
    {
        public int CalculatedTax()
        {
            return 30;
        }
    }
}
