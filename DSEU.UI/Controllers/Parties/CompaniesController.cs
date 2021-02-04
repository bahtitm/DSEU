using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using DSEU.Application.Modules.Parties.Organizations.Companies.Commands.CreateComany;
using DSEU.Application.Modules.Parties.Organizations.Companies.Commands.EditComany;
using DSEU.Application.Modules.Parties.Organizations.Companies.Commands.RemoveCompany;
using DSEU.Application.Modules.Parties.Organizations.Companies.Models;
using DSEU.Application.Modules.Parties.Organizations.Companies.Queries;
using DSEU.Devexpress.Devexpress.Options;
using DSEU.Domain.Entities;
using DSEU.Domain.Entities.CoreEntities;
using DSEU.Security.Attributes;

namespace DSEU.UI.Controllers.Parties
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Api для проведения операция с организациями (контрагенты)")]
    public class CompaniesController : ControllerBase
    {
        private readonly IMediator mediator;

        public CompaniesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: api/Companies
        [HttpGet]
        [PermissionRequirement(EntityTypeGuid.Counterparty, AccessRightsOperation.Read)]
        [ProducesResponseType(typeof(IEnumerable<CompanyDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var dataSource = await mediator.Send(new GetAllCompaniesQuery());
            return Ok(await DataSourceLoader.LoadAsync(dataSource.AsQueryable(), loadOptions));
        }

        // GET: api/Companies/1
        [HttpGet("{id}")]
        [PermissionRequirement(EntityTypeGuid.Counterparty, AccessRightsOperation.Read)]
        [ProducesResponseType(typeof(CompanyDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            return Ok(await mediator.Send(new GetCompanyByIdQuery(id)));
        }

        // POST: api/Companies
        [HttpPost]
        [PermissionRequirement(EntityTypeGuid.Counterparty, AccessRightsOperation.Create)]
        [ProducesResponseType(typeof(CompanyDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Post([FromBody] CreateCompanyCommand command)
        {
            var entity = await mediator.Send(command);
            return Ok(entity);
        }

        // PUT: api/Companies/5
        [HttpPut("{id}")]
        [PermissionRequirement(EntityTypeGuid.Counterparty, AccessRightsOperation.Edit)]
        [ProducesResponseType(typeof(CompanyDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Put(int id, [FromBody] EditCompanyCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest($"Check request: {id} not equals {command.Id}");
            }

            var entity = await mediator.Send(command);
            return Ok(entity);
        }

        // DELETE: api/Companies/5
        [HttpDelete("{id}")]
        [PermissionRequirement(EntityTypeGuid.Counterparty, AccessRightsOperation.FullAccess)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Delete(int id)
        {
            await mediator.Send(new RemoveCompanyCommand { Id = id });
            return NoContent();
        }
    }
}
