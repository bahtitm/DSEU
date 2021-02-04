using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using DSEU.Application.Dtos.Commons;
using DSEU.Application.Modules.Commons.Countries.Commands.CreateCountry;
using DSEU.Application.Modules.Commons.Countries.Commands.EditCountry;
using DSEU.Application.Modules.Commons.Countries.Commands.RemoveCountry;
using DSEU.Application.Modules.Commons.Countries.Queries.GetAllCountries;
using DSEU.Devexpress.Devexpress.Options;
using DSEU.Domain.Entities;
using DSEU.Domain.Entities.CoreEntities;
using DSEU.Security.Attributes;

namespace DSEU.UI.Controllers.Commons
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Api для проведения операция со странами")]
    public class CountryController : ControllerBase
    {
        private readonly IMediator mediator;

        public CountryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: api/Country
        [HttpGet]
        [PermissionRequirement(EntityTypeGuid.Country, AccessRightsOperation.Read)]
        [ProducesResponseType(typeof(IEnumerable<CountryDto>), 200)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var dataSource = await mediator.Send(new GetAllCountriesQuery());
            return Ok(await DataSourceLoader.LoadAsync(dataSource.AsQueryable(), loadOptions));
        }

        // POST: api/Country
        [HttpPost]
        [PermissionRequirement(EntityTypeGuid.Country, AccessRightsOperation.Create)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Post([FromBody] CreateCountryCommand command)
        {
            await mediator.Send(command);
            return Ok();

        }

        // PUT: api/Country/5
        [HttpPut("{id}")]
        [PermissionRequirement(EntityTypeGuid.Country, AccessRightsOperation.Edit)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Put(int id, [FromBody] EditCountryCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest($"Check request: {id} not equals {command.Id}");
            }

            await mediator.Send(command);

            return NoContent();
        }

        // DELETE: api/Country/5
        [HttpDelete("{id}")]
        [PermissionRequirement(EntityTypeGuid.Country, AccessRightsOperation.FullAccess)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Delete(int id)
        {
            await mediator.Send(new RemoveCountryCommand(id));
            return NoContent();
        }
    }
}
