using System;
using AspNetCoreIoC.Business.Tax.BusinessModel;
using AspNetCoreIoC.Business.Tax.Implementation;
using AspNetCoreIoC.Business.Tax.Interface;
using AspNetCoreIoC.DependencyProvider;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreIoC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            // conditional dependency resolver

            services.AddScoped<AustraliaTaxService>();
            services.AddScoped<IndiaTaxService>();           
            services.AddScoped<Func<UserLocation,ITaxService>>(
                serviceProvider => key => {
                    switch(key)
                    {
                        case UserLocation.AUSTRALIA:
                            return serviceProvider.GetService<AustraliaTaxService>();
                        case UserLocation.INDIA:
                            return serviceProvider.GetService<IndiaTaxService>();
                        default:
                            return null;
                    }

                }                
                );

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //  autofac
            var builder = new ContainerBuilder();
            builder.RegisterModule<DataBaseServiceDependency>();
            builder.Populate(services);
            var container = builder.Build();
            return new AutofacServiceProvider(container);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
