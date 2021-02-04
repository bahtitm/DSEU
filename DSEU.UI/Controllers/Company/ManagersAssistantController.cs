using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using DSEU.Application.Dtos.Company;
using DSEU.Application.Modules.Company.ManagersAssistants.Commands.CreateManagersAssistant;
using DSEU.Application.Modules.Company.ManagersAssistants.Commands.EditManagersAssistant;
using DSEU.Application.Modules.Company.ManagersAssistants.Commands.RemoveHeadAssistant;
using DSEU.Application.Modules.Company.ManagersAssistants.Queries;
using DSEU.Devexpress.Devexpress.Options;
using DSEU.Domain.Entities;
using DSEU.Domain.Entities.CoreEntities;
using DSEU.Security.Attributes;

namespace DSEU.UI.Controllers.Company
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Api для проведения операция с помощниками руководителей в организации")]
    public class ManagersAssistantController : ControllerBase
    {
        private readonly IMediator mediator;

        public ManagersAssistantController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        // GET: api/ManagersAssistant
        [HttpGet]
        [PermissionRequirement(EntityTypeGuid.ManagersAssistant, AccessRightsOperation.Read)]
        [ProducesResponseType(typeof(IEnumerable<ManagersAssistantDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var dataSource = await mediator.Send(new GetAllManagersAssistantsQuery());
            return Ok(await DataSourceLoader.LoadAsync(dataSource.AsQueryable(), loadOptions));

        }

        // POST: api/ManagersAssistant
        [HttpPost]
        [PermissionRequirement(EntityTypeGuid.ManagersAssistant, AccessRightsOperation.Create)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Post([FromBody] CreateManagersAssistantCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }

        // PUT: api/ManagersAssistant/5
        [HttpPut("{id}")]
        [PermissionRequirement(EntityTypeGuid.ManagersAssistant, AccessRightsOperation.Edit)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Put(int id, [FromBody] EditManagersAssistantCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest($"Check request: {id} not equals {command.Id}");
            }

            await mediator.Send(command);

            return NoContent();
        }

        // DELETE: api/ManagersAssistant/5
        [HttpDelete("{id}")]
        [PermissionRequirement(EntityTypeGuid.ManagersAssistant, AccessRightsOperation.FullAccess)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Delete(int id)
        {
            await mediator.Send(new RemoveManagersAssistantCommand { Id = id });
            return NoContent();
        }
    }
}
