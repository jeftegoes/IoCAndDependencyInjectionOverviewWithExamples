using HandsOnProjectPersonalBlog.Interfaces;

namespace HandsOnProjectPersonalBlog.Services
{
    public class AuthorizerService : IAuthorizerService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        public AuthorizerService(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public bool IsAuthorized()
        {
            var ipV4 = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            var validIp = _configuration.GetSection("Security").GetValue<string>("ValidIp");
            return string.Compare(ipV4, validIp) == 0;
        }
    }
}