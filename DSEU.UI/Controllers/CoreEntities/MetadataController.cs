using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using System.Threading.Tasks;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Dtos;
using DSEU.Application.Services.Interfaces;
using DSEU.Domain.Entities.Company;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.UI.Controllers.CoreEntities
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Api для получения метаданных для пользователя")]
    public class MetadataController : ControllerBase
    {
        private readonly IRecipientService recipientService;
        private readonly IReadOnlyApplicationDbContext dbContext;

        public MetadataController(IRecipientService recipientService, IReadOnlyApplicationDbContext dbContext)
        {
            this.recipientService = recipientService;
            this.dbContext = dbContext;
        }

        // GET: api/Metadata
        [HttpGet]
        [ProducesResponseType(typeof(MetadataDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Get()
        {
            var accessRights = await recipientService.GetUserAccessRightsOperations(User.UserId());
            var user = await dbContext.Query<User>().FirstOrDefaultAsync(p => p.Id == User.UserId());
            var isManagerAssistant = await dbContext.Query<ManagersAssistant>().Where(p => p.Status == Domain.Entities.Status.Active)
                .AnyAsync(p => p.AssistantId == user.Id);

            MetadataDto metadataObject = new MetadataDto
            {
                Name = user.Name,
                IsManagerAssistant = isManagerAssistant,
                EmployeeId = User.UserId(),
                Roles = await recipientService.GetRecipientRoles(User.UserId()),
                AccessRights = accessRights.Select(p => new { p.entityType, p.operation }),
                PersonalPhotoHash = user.PersonalPhotoHash
            };
            return Ok(metadataObject);
        }
    }
}
