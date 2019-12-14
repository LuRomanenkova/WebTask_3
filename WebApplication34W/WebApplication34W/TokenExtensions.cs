using Microsoft.AspNetCore.Builder;
using WebApplication34W;

public static class TokenExtensions
{
    public static IApplicationBuilder UseMidW(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<TokenMiddleware>();
    }
}
