using AspNetCoreIoC.DbServices.Implementation;
using AspNetCoreIoC.DbServices.Interface;
using Autofac;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreIoC.DependencyProvider
{
    public class DataBaseServiceDependency:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<ICustomerService>().As<CustomerService>();
        }
    }
}
