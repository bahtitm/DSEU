using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using DSEU.Application.Dtos.Company;
using DSEU.Application.Modules.Company.JobTitles.Commands.CreateJobTitle;
using DSEU.Application.Modules.Company.JobTitles.Commands.EditJobTitle;
using DSEU.Application.Modules.Company.JobTitles.Commands.RemoveJobTitle;
using DSEU.Application.Modules.Company.JobTitles.Queries.GetAllJobTitles;
using DSEU.Devexpress.Devexpress.Options;
using DSEU.Domain.Entities;
using DSEU.Domain.Entities.CoreEntities;
using DSEU.Security.Attributes;

namespace DSEU.UI.Controllers.Company
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Api для проведения операция с должностями сотрудников организации")]
    public class JobTitleController : ControllerBase
    {
        private readonly IMediator mediator;

        public JobTitleController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        // GET: api/JobTitle
        [HttpGet]
        [PermissionRequirement(EntityTypeGuid.JobTitle, AccessRightsOperation.Read)]
        [ProducesResponseType(typeof(IEnumerable<JobTitleDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var dataSource = await mediator.Send(new GetAllJobTitlesQuery());
            return Ok(await DataSourceLoader.LoadAsync(dataSource.AsQueryable(), loadOptions));
        }

        // POST: api/JobTitle
        [HttpPost]
        [PermissionRequirement(EntityTypeGuid.JobTitle, AccessRightsOperation.Create)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Post([FromBody] CreateJobTitleCommand command)
        {
            await mediator.Send(command);
            return Ok();

        }

        // PUT: api/JobTitle/5
        [HttpPut("{id}")]
        [PermissionRequirement(EntityTypeGuid.JobTitle, AccessRightsOperation.Edit)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Put(int id, [FromBody] EditJobTitleCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest($"Check request: {id} not equals {command.Id}");
            }

            await mediator.Send(command);

            return NoContent();
        }

        // DELETE: api/JobTitle/5
        [HttpDelete("{id}")]
        [PermissionRequirement(EntityTypeGuid.JobTitle, AccessRightsOperation.FullAccess)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Delete(int id)
        {
            await mediator.Send(new RemoveJobTitleCommand { Id = id });
            return NoContent();
        }
    }
}
