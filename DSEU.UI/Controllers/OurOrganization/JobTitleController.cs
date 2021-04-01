using DSEU.Application.Modules.Company.OurOrganization.JobTitles.Commands.CreateJobTitle;
using DSEU.Application.Modules.Company.OurOrganization.JobTitles.Commands.DeleteJobTitle;
using DSEU.Application.Modules.Company.OurOrganization.JobTitles.Commands.UpdateJobTitle;
using DSEU.Application.Modules.Company.OurOrganization.JobTitles.Queries.GetAllJobTitles;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace DSEU.UI.Controllers.OurOrganization
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Api для должности")]
    public class JobTitleController : ControllerBase
    {
        private readonly IMediator mediator;

        public JobTitleController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await mediator.Send(new GetAllJobTitlesQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateJobTitleCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateJobTitleCommand command)
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
            await mediator.Send(new DeleteJobTitleCommand(id));
            return NoContent();
        }
    }
}
