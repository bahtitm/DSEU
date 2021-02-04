using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using DSEU.Application.Dtos.Commons;
using DSEU.Application.Modules.Commons.Localities.Commands.CreateLocality;
using DSEU.Application.Modules.Commons.Localities.Commands.EditLocality;
using DSEU.Application.Modules.Commons.Localities.Commands.RemoveLocality;
using DSEU.Application.Modules.Commons.Localities.Queries.GetAllLocalities;
using DSEU.Devexpress.Devexpress.Options;
using DSEU.Domain.Entities;
using DSEU.Domain.Entities.CoreEntities;
using DSEU.Security.Attributes;

namespace DSEU.UI.Controllers.Commons
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Api для проведения операция с населенными пунктами")]
    public class LocalityController : ControllerBase
    {
        private readonly IMediator mediator;

        public LocalityController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        // GET: api/Locality
        [HttpGet]
        [PermissionRequirement(EntityTypeGuid.Locality, AccessRightsOperation.Read)]
        [ProducesResponseType(typeof(IEnumerable<LocalityDto>), 200)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var dataSource = await mediator.Send(new GetAllLocalitiesQuery());
            return Ok(await DataSourceLoader.LoadAsync(dataSource.AsQueryable(), loadOptions));
        }

        // POST: api/Locality
        [HttpPost]
        [PermissionRequirement(EntityTypeGuid.Locality, AccessRightsOperation.Create)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Post([FromBody] CreateLocalityCommand command)
        {
            await mediator.Send(command);
            return Ok();

        }

        // PUT: api/Locality/5
        [HttpPut("{id}")]
        [PermissionRequirement(EntityTypeGuid.Locality, AccessRightsOperation.Edit)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Put(int id, [FromBody]EditLocalityCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest($"Check request: {id} not equals {command.Id}");
            }

            await mediator.Send(command);

            return NoContent();
        }

        // DELETE: api/Locality/5
        [HttpDelete("{id}")]
        [PermissionRequirement(EntityTypeGuid.Locality, AccessRightsOperation.FullAccess)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Delete(int id)
        {
            await mediator.Send(new RemoveLocalityCommand(id));
            return NoContent();
        }
    }
}
