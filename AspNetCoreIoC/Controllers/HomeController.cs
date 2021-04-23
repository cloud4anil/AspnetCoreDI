using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreIoC.Models;
using AspNetCoreIoC.Business.Tax.BusinessModel;
using AspNetCoreIoC.Business.Tax.Interface;
using AspNetCoreIoC.DbServices.Interface;

namespace AspNetCoreIoC.Controllers
{
    public class HomeController : Controller
    {
       // resolve multiple class file implemented by single interface 
        private readonly Func<UserLocation, ITaxService> taxService;

        private readonly ICustomerService _customerService;

        public HomeController(Func<UserLocation, ITaxService> taxService, ICustomerService customerService)
        {
            this.taxService = taxService;
            _customerService = customerService;
        }
        public IActionResult Index()
        {
            var tax = taxService(UserLocation.AUSTRALIA).CalculatedTax();
            var isActive = _customerService.IsActiveCustomer();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
