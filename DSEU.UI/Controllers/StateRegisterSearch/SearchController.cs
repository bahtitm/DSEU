using DSEU.Application.Modules.StateRegisterSearch.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace DSEU.UI.Controllers.StateRegisterSearch
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Api для State Register Search")]
    public class SearchController : ControllerBase
    {
        private readonly IMediator mediator;

        public SearchController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> ElasticSearch([FromBody] GetAllStateRegistersQuery query)
        {
            var result = await mediator.Send(query);
            return Ok(result);
        }
    }
}
