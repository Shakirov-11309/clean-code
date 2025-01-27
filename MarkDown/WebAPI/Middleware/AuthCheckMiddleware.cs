namespace WebAPI.Middleware
{
    public class AuthCheckMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthCheckMiddleware(RequestDelegate next) 
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context) 
        {
            if (!context.Request.Cookies.ContainsKey("cookie")) 
            {
                context.Response.Redirect("/login");
            }
            await _next(context);
        }
    }
}
