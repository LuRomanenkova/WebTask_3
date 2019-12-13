using System.Net.Http;
using Microsoft.AspNetCore.Http;

namespace WebApplication37W
{
    public class SmsMessageSender : IMessageSender
    {
        private string SmsMessageSenderContext;
        public SmsMessageSender(HttpContext context)
        {
            var is_req = context.Request.Cookies.TryGetValue("text", out string val);
            if (is_req)
            {
                SmsMessageSenderContext = val;
            }
            else
            {
                context.Response.Cookies.Append("text", "Hello! Have a good day :)");
                SmsMessageSenderContext = "Empty string!";
            }
        }
        
        public string Send()
        {
            return SmsMessageSenderContext;
        }
    }
}