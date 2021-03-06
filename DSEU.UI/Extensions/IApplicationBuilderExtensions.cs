using Microsoft.AspNetCore.Builder;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace DSEU.UI.Extensions
{
    public static class IApplicationBuilderExtensions
    {
        public static void UseSwagger(this IApplicationBuilder app)
        {
            SwaggerBuilderExtensions.UseSwagger(app);

            app.UseSwaggerUI(config =>
            {
                config.DefaultModelsExpandDepth(-1);
                config.SwaggerEndpoint("/swagger/v2/swagger.json", "DSEU API V1");
                config.RoutePrefix = "swagger";
                config.DocExpansion(DocExpansion.None);
                config.EnableFilter();
                config.OAuthConfigObject = new OAuthConfigObject()
                {
                    AppName  = "DSEU.UI",
                    ClientId = "DSEU.UI",
                    UsePkceWithAuthorizationCodeGrant = true
                };
              
            });
        }
    }
}
