using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MultipleApiQueriesTest.Clients;
using MultipleApiQueriesTest.DomainLogic;
using Refit;
using System;

namespace MultipleApiQueriesTest.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddScoped<IOffersService, OffersService>();
            services
               .AddRefitClient<IApi1Client>()
               .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://api1/"));

            services
               .AddRefitClient<IApi2Client>()
               .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://api2/"));

            services
               .AddRefitClient<IApi2Client>()
               .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://api3/"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
