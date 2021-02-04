using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using DSEU.Application.Dtos.Commons;
using DSEU.Application.Modules.Commons.Regions.Commands.CreateRegion;
using DSEU.Application.Modules.Commons.Regions.Commands.EditRegion;
using DSEU.Application.Modules.Commons.Regions.Commands.RemoveRegion;
using DSEU.Application.Modules.Commons.Regions.Queries.GetAllRegions;
using DSEU.Devexpress.Devexpress.Options;
using DSEU.Domain.Entities;
using DSEU.Domain.Entities.CoreEntities;
using DSEU.Security.Attributes;

namespace DSEU.UI.Controllers.Commons
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Api для проведения операция с регионами")]
    public class RegionController : ControllerBase
    {
        private readonly IMediator mediator;

        public RegionController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: api/Region
        [HttpGet]
        [PermissionRequirement(EntityTypeGuid.Region, AccessRightsOperation.Read)]
        [ProducesResponseType(typeof(IEnumerable<RegionDto>), 200)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var dataSource = await mediator.Send(new GetAllRegionsQuery());
            return Ok(await DataSourceLoader.LoadAsync(dataSource.AsQueryable(), loadOptions));
        }

        // POST: api/Region
        [HttpPost]
        [PermissionRequirement(EntityTypeGuid.Region, AccessRightsOperation.Create)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Post([FromBody]CreateRegionCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }


        // PUT: api/Region/5
        [HttpPut("{id}")]
        [PermissionRequirement(EntityTypeGuid.Region, AccessRightsOperation.Edit)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Put(int id, [FromBody] EditRegionCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest($"Check request: {id} not equals {command.Id}");
            }

            await mediator.Send(command);

            return NoContent();
        }

        // DELETE: api/Region/5
        [HttpDelete("{id}")]
        [PermissionRequirement(EntityTypeGuid.Region, AccessRightsOperation.FullAccess)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Delete(int id)
        {
            await mediator.Send(new RemoveRegionCommand(id));
            return NoContent();
        }
    }
}