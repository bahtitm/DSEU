using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using DSEU.Application.Dtos;
using DSEU.Application.Modules.Recipients.Queries.GetAllRecipients;
using DSEU.Devexpress.Devexpress.Options;

namespace DSEU.UI.Controllers.CoreEntities
{
    [Route("api/[controller]")]
    [SwaggerTag("Api для проведения операция с субъектами прав доступа")]
    [ApiController]
    public class RecipientController : Controller
    {
        private readonly IMediator mediator;

        public RecipientController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Получить все субъекты прав доступа
        /// </summary>
        /// <param name="loadOptions"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<RecipientDto>), 200)]
        public async Task<IActionResult> Get([FromQuery]DataSourceLoadOptions loadOptions)
        {
            var dataSource = await mediator.Send(new GetAllRecipientsQuery());
            return Ok(await DataSourceLoader.LoadAsync(dataSource.AsQueryable(), loadOptions));
        }
    }
}
