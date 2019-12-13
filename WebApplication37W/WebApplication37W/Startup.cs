using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebApplication37W
{
    public class MessegeService
    {
        private IMessageSender _sender;

        public MessegeService(IMessageSender sender)
        {
            _sender = sender;
        }

        public string Send()
        {
            return _sender.Send();
        }
    }
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession();

           // services.AddTransient<IMessageSender, SmsMessageSender>();
            //services.AddTransient<MessegeService>();
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseSession();
            
            app.Map("/email", Email);
            app.Map("/sms", SMS);
            

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }

        private static void Email(IApplicationBuilder app)
        {
            
            app.Run(async context =>
            {
                var ms = new MessegeService(new EmailMessageSender(context));
                await context.Response.WriteAsync(ms.Send());
            });
        }
        
        private static void SMS(IApplicationBuilder app)
        {
            
            app.Run(async context =>
            {
                var ms = new MessegeService(new SmsMessageSender(context));
                await context.Response.WriteAsync(ms.Send());
            });
        }
    }
}