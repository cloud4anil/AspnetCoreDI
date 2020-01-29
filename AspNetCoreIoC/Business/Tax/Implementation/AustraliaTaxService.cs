using AspNetCoreIoC.Business.Tax.Interface;


namespace AspNetCoreIoC.Business.Tax.Implementation
{
    public class AustraliaTaxService : ITaxService
    {
        public int CalculatedTax()
        {
            return 20;
        }
    }
}
