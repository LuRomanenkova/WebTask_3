using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using WebApplication34R;

public static class TokenExtensions
{
    public static IApplicationBuilder UseToken(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<TokenMiddleware>();
    }
}