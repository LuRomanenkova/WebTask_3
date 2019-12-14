using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebApplication34R
{
    public class TokenMiddleware
    {
         private readonly RequestDelegate _next;
        
            public TokenMiddleware(RequestDelegate next)
            {
                this._next = next;
            }

            public async Task InvokeAsync(HttpContext context)
            {
                var token = context.Request.Query["token"];
                if (token != "1")
                {
                    context.Response.StatusCode = 403;
                    await context.Response.WriteAsync("Token is invalid");
                }
                else
                {
                    double x = 15;
                    double y = 13;
                    double z = 0;
                    z = Math.Sin(x) / x + Math.Log(5) / y + y * Math.Cos(y);
                    await context.Response.WriteAsync($"sin({x}) / {x} + log(5) / {y} + {y} * cos({y}) = {z}");
                    await _next.Invoke(context);
                }
            }
    }
}