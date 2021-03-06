using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace DSEU.UI.Controllers
{
    [AllowAnonymous]
    ///[ApiVersion("1.1")]
    public class OidcConfigurationController : Controller
    {
        private readonly ILogger<OidcConfigurationController> _logger;

        public OidcConfigurationController(IClientRequestParametersProvider clientRequestParametersProvider, ILogger<OidcConfigurationController> logger)
        {
            ClientRequestParametersProvider = clientRequestParametersProvider;
            _logger = logger;
        }

        public IClientRequestParametersProvider ClientRequestParametersProvider { get; }

        [HttpGet("_configuration/{clientId}")]
       /// [MapToApiVersion("1.1")]
        public IActionResult GetClientRequestParameters([FromRoute]string clientId)
        {
            string hostName = this.Request.Host.Host;
            var parameters = ClientRequestParametersProvider.GetClientParameters(HttpContext, clientId);

            if (clientId.Contains("prod"))
            {
                UriBuilder redirectUriBuilder = new UriBuilder(parameters["redirect_uri"])
                {
                    Host = hostName
                };
                parameters["redirect_uri"] = redirectUriBuilder.Uri.ToString();

                UriBuilder postLogoutUriBuilder = new UriBuilder(parameters["post_logout_redirect_uri"])
                {
                    Host = hostName
                };
                parameters["post_logout_redirect_uri"] = postLogoutUriBuilder.Uri.ToString();
            }

            return Ok(parameters);
        }
    }
}
