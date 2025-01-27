using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using WebAPI.Controllers;

namespace WebAPI.Routing
{
    public class RoutingApp 
    {
        public void Configure(IApplicationBuilder app) 
        {
            var routeBuilder = new RouteBuilder(app);
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints => 
            {
                endpoints.MapControllers();
            });
        }
    }
}
