using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
public class TokenMiddleware
{
        private readonly RequestDelegate _next;
        string pattern;
        public TokenMiddleware(RequestDelegate next, string pattern)
        {
            this._next = next;
            this.pattern = pattern;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Query["token"];
            if (token!=pattern)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Token is invalid");
            }
            else
            {
                double x = 5;
                double y = 10;
                double z = 0;

                z = Math.Pow(x, Math.Log(x, y) + Math.Pow(y, Math.Log(y, x)));
                await context.Response.WriteAsync($"x^log_y(x) + y^log_x(y) = {z}");
                await _next.Invoke(context);
            }
        }
    }
