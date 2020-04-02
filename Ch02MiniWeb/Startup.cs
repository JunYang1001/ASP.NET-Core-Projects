using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ch02MiniWeb.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace Ch02MiniWeb
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ICountryRespository,CountryRepository>();
            services.AddDirectoryBrowser();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseDirectoryBrowser();
            app.Map("/country", countryApp =>
            {
                countryApp.Run(async (context) =>
                {
                   // var country = provider.GetRequiredService<ICountryRespository>();
                    var query = context.Request.Query["q"];
                    var list = (app.ApplicationServices).GetService<ICountryRespository>().AllBy(query).ToList();
                    var json = JsonConvert.SerializeObject(list);

                    await context.Response.WriteAsync(json);
                });
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    //var country = provider.GetService<ICountryRespository>();
                    //var query=context.Request.Query["q"];
                    //var countries = country.AllBy(query).ToList();
                    //var serializeObjectjson = JsonConvert.SerializeObject(countries);
                    await context.Response.WriteAsync("Invalid call");
                });
            });
        }
    }
}
