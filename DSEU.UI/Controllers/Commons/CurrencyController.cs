using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using DSEU.Application.Dtos.Commons;
using DSEU.Application.Modules.Commons.Currencies.Commands.CreateCurrency;
using DSEU.Application.Modules.Commons.Currencies.Commands.EditCurrency;
using DSEU.Application.Modules.Commons.Currencies.Commands.RemoveCurrency;
using DSEU.Application.Modules.Commons.Currencies.Queries.GetAllCurrencies;
using DSEU.Devexpress.Devexpress.Options;
using DSEU.Domain.Entities;
using DSEU.Domain.Entities.CoreEntities;
using DSEU.Security.Attributes;

namespace DSEU.UI.Controllers.Commons
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Api для проведения операция с валютами")]
    public class CurrencyController : ControllerBase
    {
        private readonly IMediator mediator;

        public CurrencyController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: api/Currency
        [HttpGet]
        [PermissionRequirement(EntityTypeGuid.Currency, AccessRightsOperation.Read)]
        [ProducesResponseType(typeof(IEnumerable<CurrencyDto>), 200)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var dataSource = await mediator.Send(new GetAllCurrenciesQuery());
            return Ok(await DataSourceLoader.LoadAsync(dataSource.AsQueryable(), loadOptions));
        }

        // POST: api/Currency
        [HttpPost]
        [PermissionRequirement(EntityTypeGuid.Currency, AccessRightsOperation.Create)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Post([FromBody] CreateCurrencyCommand command)
        {
            await mediator.Send(command);
            return Ok();

        }

        // PUT: api/Currency/5
        [HttpPut("{id}")]
        [PermissionRequirement(EntityTypeGuid.Currency, AccessRightsOperation.Edit)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Put(int id, [FromBody] EditCurrencyCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest($"Check request: {id} not equals {command.Id}");
            }

            await mediator.Send(command);

            return NoContent();
        }

        // DELETE: api/Currency/5
        [HttpDelete("{id}")]
        [PermissionRequirement(EntityTypeGuid.Currency, AccessRightsOperation.FullAccess)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Delete(int id)
        {
            await mediator.Send(new RemoveCurrencyCommand(id));
            return NoContent();
        }
    }
}
