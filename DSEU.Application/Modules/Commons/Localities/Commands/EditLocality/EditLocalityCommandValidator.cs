using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using DSEU.Application.Common.Constants;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.Commons;

namespace DSEU.Application.Modules.Commons.Localities.Commands.EditLocality
{
    public class EditLocalityCommandValidator : AbstractValidator<EditLocalityCommand>
    {
        private readonly IReadOnlyApplicationDbContext dbContext;

        public EditLocalityCommandValidator(IReadOnlyApplicationDbContext dbContext, ILocalizationService localizationService)
        {
            this.dbContext = dbContext;
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(locality => locality.Name)
                 .NotEmpty()
                 .MaximumLength(60)
                 .WithName(localizationService[LocalizationKeys.PropertyNames.Name]);

            RuleFor(locality => locality.RegionId)
                 .NotEmpty()
                 .MustAsync(async (regionId, ct) => await dbContext.IsActiveAsync<Region>(regionId, ct))
                 .WithMessage(localizationService.StatusMustBeActive)
                 .WithName(localizationService[LocalizationKeys.PropertyNames.Region])
                 .WhenAsync(RegionIdWasModified);
        }

        private async Task<bool> RegionIdWasModified(EditLocalityCommand command, CancellationToken cancellationToken)
        {
            return await dbContext.Query<Locality>().AnyAsync(p => p.Id == command.Id && p.RegionId != command.RegionId);
        }
    }
}
