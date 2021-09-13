using Microsoft.AspNetCore.Builder;

namespace MishaTelecoms.API.Config
{
    public static class Middleware
    {
        public static IApplicationBuilder AddMiddleware(this IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            return app;
        }
    }
}
