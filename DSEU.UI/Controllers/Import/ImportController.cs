using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using DSEU.Application.Common.Interfaces;
using DSEU.Security.Policies;

namespace DSEU.UI.Controllers.Import
{
    [Route("api/[controller]")]
    [SwaggerTag("Api для проведения операция с импортом данных")]
    [Authorize(Policy = GeneralPolicy.Admin)]
    [ApiController]
    public class ImportController : ControllerBase
    {
        private readonly IImportDataService importService;
        public ImportController(IImportDataService importService)
        {
            this.importService = importService;
        }

        // POST: api/Import/JobTitles
        /// <summary>
        /// Импортировать должности
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [HttpPost("JobTitles")]
        public async Task<IActionResult> ImportJobTitles([FromForm]IFormFile file)
        {
            await importService.ImportJobTitles(file.OpenReadStream());
            return NoContent();
        }

        // POST: api/Import/Companies
        /// <summary>
        /// Импортировать организации контрагентов
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [HttpPost("Companies")]
        public async Task<IActionResult> ImportCompanies([FromForm]IFormFile file)
        {
            await importService.ImportCompanies(file.OpenReadStream());
            return NoContent();
        }

        // POST: api/Import/Banks
        /// <summary>
        /// Импортировать банки
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [HttpPost("Banks")]
        public async Task<IActionResult> ImportBanks([FromForm]IFormFile file)
        {
            await importService.ImportBanks(file.OpenReadStream());
            return NoContent();
        }

        // POST: api/Import/Persons
        /// <summary>
        /// Импортировать физические лица
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [HttpPost("Persons")]
        public async Task<IActionResult> ImportPersons([FromForm]IFormFile file)
        {
            await importService.ImportPersons(file.OpenReadStream());
            return NoContent();
        }

        // POST: api/Import/Employees
        /// <summary>
        /// Импортировать сотрудников
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [HttpPost("Employees")]
        public async Task<IActionResult> ImportEmployees([FromForm]IFormFile file)
        {
            await importService.ImportEmployees(file.OpenReadStream());
            return NoContent();
        }

    }
}