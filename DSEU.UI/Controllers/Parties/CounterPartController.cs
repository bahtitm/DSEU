using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using DSEU.Application.Modules.Parties.CounterParts.Models;
using DSEU.Application.Modules.Parties.CounterParts.Queries.GetAllCounterPartsQuery;
using DSEU.Devexpress.Devexpress.Options;
using DSEU.Domain.Entities;
using DSEU.Domain.Entities.CoreEntities;
using DSEU.Security.Attributes;

namespace DSEU.UI.Controllers.Parties
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Api для получния сведений о всех контрагентах")]
    public class CounterPartController : ControllerBase
    {
        private readonly IMediator mediator;

        public CounterPartController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        // GET: api/CounterPart
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CounterPartDto>), StatusCodes.Status200OK)]
        [PermissionRequirement(EntityTypeGuid.Counterparty, AccessRightsOperation.Read)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var dataSource = await mediator.Send(new GetAllCounterPartsQuery());
            
            return Ok(await DataSourceLoader.LoadAsync(dataSource.AsQueryable(), loadOptions));
        }

    }
}
