using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPI.Filter
{
    public class UserAccess : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            throw new NotImplementedException();
        }
    }
}
