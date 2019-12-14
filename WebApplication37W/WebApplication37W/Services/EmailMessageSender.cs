using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Http;

namespace WebApplication37W 
{
    public class EmailMessageSender : IMessageSender
    {
        public string EmailMessageSenderContext;

        public EmailMessageSender(HttpContext context)
        {
            string res = context.Session.GetString("text");
            if (res == null)
            {
                EmailMessageSenderContext = "Empty string!";
                context.Session.SetString("text", "Hello! I'm from session! Have a good day :)");
            }
            else
            {
                EmailMessageSenderContext = res;
            }
        }
        
        public string Send()
        {
            return EmailMessageSenderContext;
        }
    }
}