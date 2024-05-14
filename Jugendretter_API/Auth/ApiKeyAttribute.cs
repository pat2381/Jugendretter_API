using Microsoft.AspNetCore.Mvc;

namespace Jugendretter_API.Auth
{
    public class ApiKeyAttribute: ServiceFilterAttribute
    {
        public ApiKeyAttribute():base(typeof(ApiKeyAuthFilter))
        {
            
        }
    }
}
