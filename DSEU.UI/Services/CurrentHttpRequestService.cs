using Microsoft.AspNetCore.Http;
using DSEU.Application.Common.Interfaces;

namespace DSEU.UI.Services
{
    public class CurrentHttpRequestService : ICurrentHttpRequestService
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public CurrentHttpRequestService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        public string HostName => httpContextAccessor?.HttpContext?.Connection?.RemoteIpAddress.MapToIPv4().ToString();
        public string UserAgent => httpContextAccessor?.HttpContext?.Request?.Headers["User-Agent"].ToString();
    }
}
