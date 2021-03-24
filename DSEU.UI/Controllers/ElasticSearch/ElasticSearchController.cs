using DSEU.Application.Modules.ElasticSearch.Commands.CreateElasticSearch;
using DSEU.Application.Modules.ElasticSearch.Commands.DeleteElasticSearch;
using DSEU.Application.Modules.ElasticSearch.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace DSEU.UI.Controllers.ElasticSearch
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Api для ElasticSearch")]
    public class ElasticSearchController : ControllerBase
    {
        private readonly IMediator mediator;

        public ElasticSearchController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("search")]
        public async Task<IActionResult> ElasticSearch([FromBody] GetElasticSearchQuery query)
        {
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateElasticSearchCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateElasticSearchCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest($"Check request: {id} not equals {command.Id}");
            }
            await mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await mediator.Send(new DeleteElasticSearchCommand(id));
            return NoContent();
        }
    }
}

