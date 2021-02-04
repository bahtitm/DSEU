using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using DSEU.Application.Modules.Parties.Organizations.Banks.Commands.CreateBank;
using DSEU.Application.Modules.Parties.Organizations.Banks.Commands.EditBank;
using DSEU.Application.Modules.Parties.Organizations.Banks.Commands.RemoveBank;
using DSEU.Application.Modules.Parties.Organizations.Banks.Models;
using DSEU.Application.Modules.Parties.Organizations.Banks.Queries;
using DSEU.Devexpress.Devexpress.Options;
using DSEU.Domain.Entities;
using DSEU.Domain.Entities.CoreEntities;
using DSEU.Security.Attributes;

namespace DSEU.UI.Controllers.Parties
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Api для проведения операция с банками (контрагенты)")]
    public class BankController : ControllerBase
    {
        private readonly IMediator mediator;

        public BankController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: api/Banks
        [HttpGet]
        [PermissionRequirement(EntityTypeGuid.Counterparty, AccessRightsOperation.Read)]
        [ProducesResponseType(typeof(IEnumerable<BankDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var dataSource = await mediator.Send(new GetAllBanksQuery());
            return Ok(await DataSourceLoader.LoadAsync(dataSource.AsQueryable(), loadOptions));
        }

        // GET: api/Banks/1
        [HttpGet("{id}")]
        [PermissionRequirement(EntityTypeGuid.Counterparty, AccessRightsOperation.Read)]
        [ProducesResponseType(typeof(BankDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            return Ok(await mediator.Send(new GetBankByIdQuery(id)));
        }

        // POST: api/Banks
        [HttpPost]
        [PermissionRequirement(EntityTypeGuid.Counterparty, AccessRightsOperation.Create)]
        [ProducesResponseType(typeof(BankDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Post([FromBody] CreateBankCommand command)
        {
            var entity = await mediator.Send(command);
            return Ok(entity);
        }

        // PUT: api/Banks/5
        [HttpPut("{id}")]
        [PermissionRequirement(EntityTypeGuid.Counterparty, AccessRightsOperation.Edit)]
        [ProducesResponseType(typeof(BankDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Put(int id, [FromBody] EditBankCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest($"Check request: {id} not equals {command.Id}");
            }

            var entity = await mediator.Send(command);

            return Ok(entity);
        }

        // DELETE: api/Banks/5
        [HttpDelete("{id}")]
        [PermissionRequirement(EntityTypeGuid.Counterparty, AccessRightsOperation.FullAccess)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Delete(int id)
        {
            await mediator.Send(new RemoveBankCommand { Id = id });
            return NoContent();
        }
    }
}
