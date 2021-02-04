using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Web;
using DSEU.UI.Authorization;

namespace DSEU.UI.Middleware
{
    public class MustChangePasswordMiddleware
    {
        private readonly RequestDelegate _next;

        public MustChangePasswordMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Session.GetString(SessionKeys.UserFirstTimeLogin) != null
               && context.Request.Path != new PathString("/Identity/Account/MustChangePassword")
               && context.Request.Path != new PathString("/SetLanguage"))
            {
                var returnUrl = context.Request.Path.Value == "/" ? "" : "?returnUrl=" + HttpUtility.UrlEncode(context.Request.Path.Value);
                context.Response.Redirect("/Identity/Account/MustChangePassword" + returnUrl);
            }
            else
            {
                await _next(context);
            }
        }
    }
    public static class MustChangePasswordMiddlewareExtensions
    {
        public static IApplicationBuilder UseMustChangePasswordOnFirstLogin(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MustChangePasswordMiddleware>();
        }
    }
}

