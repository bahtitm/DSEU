using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using DSEU.Application.Dtos.CoreEntities;
using DSEU.Application.Modules.CoreEntities.Logins.Queries;
using DSEU.Devexpress.Devexpress.Options;
using DSEU.Security.Policies;

namespace DSEU.UI.Controllers.CoreEntities
{
    [Route("api/[controller]")]
    [SwaggerTag("Api для учетных записей")]
    [Authorize(Policy = GeneralPolicy.Admin)]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator mediator;

        public LoginController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: api/Login
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<LoginDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var dataSource = await mediator.Send(new GetAllLoginsQuery());
            return Ok(DataSourceLoader.LoadAsync(dataSource.AsQueryable(), loadOptions));
        }

        //GET: api/Login/id
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(LoginDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            return Ok(await mediator.Send(new GetLoginsByIdQuery(id)));
        }

    }
}