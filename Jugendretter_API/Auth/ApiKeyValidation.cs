using Jugendretter_API.Entities;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace Jugendretter_API.Auth
{
    public class ApiKeyValidation : IApiKeyValidation
    {
        private readonly IConfiguration _configuration;
        private readonly JugendretterDBContext _context;

        public ApiKeyValidation(JugendretterDBContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;
        }
        public bool IsValidApiKey(string userApiKey)
        {
            if (string.IsNullOrWhiteSpace(userApiKey))
                return false;
            ApiKey apiKey = _context.ApiKeys.FirstOrDefault(x => x.API_Key == userApiKey);
            if (apiKey == null || apiKey.API_Key != userApiKey)
                return false;
            return true;
        }
    }
}
