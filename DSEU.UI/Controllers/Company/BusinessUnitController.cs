using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using DSEU.Application.Dtos.Company;
using DSEU.Application.Modules.Company.BusinessUnits.Commands.CreateBusinessUnit;
using DSEU.Application.Modules.Company.BusinessUnits.Commands.EditBusinessUnit;
using DSEU.Application.Modules.Company.BusinessUnits.Commands.RemoveBusinessUnit;
using DSEU.Application.Modules.Company.BusinessUnits.Queries.GetAllBusinessUnits;
using DSEU.Application.Modules.Company.BusinessUnits.Queries.GetBusinessUnitsById;
using DSEU.Devexpress.Devexpress.Options;
using DSEU.Domain.Entities;
using DSEU.Domain.Entities.CoreEntities;
using DSEU.Security.Attributes;

namespace DSEU.UI.Controllers.Company
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Наша организация. Это организация где установлен документооборот")]
    public class BusinessUnitController : ControllerBase
    {
        private readonly IMediator mediator;

        public BusinessUnitController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: api/BusinessUnit
        [HttpGet]
        [PermissionRequirement(EntityTypeGuid.BusinessUnit, AccessRightsOperation.Read)]
        [ProducesResponseType(typeof(IEnumerable<BusinessUnitDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var dataSource = await mediator.Send(new GetAllBusinessUnitsQuery());
            return Ok(await DataSourceLoader.LoadAsync(dataSource.AsQueryable(), loadOptions));
        }

        // GET: api/BusinessUnit/id
        [HttpGet("{id}")]
        [PermissionRequirement(EntityTypeGuid.BusinessUnit, AccessRightsOperation.Read)]
        [ProducesResponseType(typeof(BusinessUnitDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetById(int id)
        {
            var dataSource = await mediator.Send(new GetBusinessUnitsByIdQuery(id));
            return Ok(dataSource);
        }


        // POST: api/BusinessUnit
        [HttpPost]
        [PermissionRequirement(EntityTypeGuid.BusinessUnit, AccessRightsOperation.Create)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Post([FromBody] CreateBusinessUnitCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }

        // PUT: api/BusinessUnit/5
        [HttpPut("{id}")]
        [PermissionRequirement(EntityTypeGuid.BusinessUnit, AccessRightsOperation.Edit)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Put(int id, [FromBody] EditBusinessUnitCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest($"Check request: {id} not equals {command.Id}");
            }

            await mediator.Send(command);

            return NoContent();
        }

        // DELETE: api/BusinessUnit/5
        [HttpDelete("{id}")]
        [PermissionRequirement(EntityTypeGuid.BusinessUnit, AccessRightsOperation.FullAccess)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Delete(int id)
        {
            await mediator.Send(new RemoveBusinessUnitCommand { Id = id });
            return NoContent();
        }
    }
}
