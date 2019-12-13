using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebApplication33W
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Map("/index", Index);
            app.Map("/about", About);
            
            app.Run(async (context) => { await context.Response.WriteAsync("Page Not Found"); });
        }

        private static void Index(IApplicationBuilder app)
        {
            double x = 10;
            double y = 15;
            double z = 0;

            z = (x * Math.Cos(x)) / Math.Sqrt(Math.Pow(x, 3) + 3 * y + y / x);
            
            app.Run(async (context) => { await context.Response.WriteAsync($"xCos(x)/(Root(x^3 + 3y + y/x)) = {z}"); });
        }
        
        private static void About(IApplicationBuilder app)
        {
            double x = 10;
            double y = 15;
            double z = 0;

            z = (Math.Sqrt(Math.Pow(x, 3) + 3 * y + y / x) / (x * Math.Cos(x)));
            
            app.Run(async (context) => { await context.Response.WriteAsync($"(Root(x^3 + 3y + y/x) / xCos(x))) = {z}"); });
        }
    }
}