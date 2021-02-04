using FluentValidation;
using DSEU.Application.Common.Constants;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.Commons;

namespace DSEU.Application.Modules.Commons.Regions.Commands.CreateRegion
{
    public class CreateRegionCommandValidator : AbstractValidator<CreateRegionCommand>
    {
        public CreateRegionCommandValidator(ILocalizationService localizationService,
            IReadOnlyApplicationDbContext dbContext)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(region => region.CountryId)
               .NotEmpty()
               .MustAsync(async (id, ct) => await dbContext.IsActiveAsync<Country>(id, ct))
               .WithMessage(localizationService.StatusMustBeActive)
               .WithName(localizationService[LocalizationKeys.PropertyNames.Country]);

            RuleFor(region => region.Name)
                .NotEmpty()
                .MaximumLength(60)
                .WithName(localizationService[LocalizationKeys.PropertyNames.Name]);
        }
    }
}
