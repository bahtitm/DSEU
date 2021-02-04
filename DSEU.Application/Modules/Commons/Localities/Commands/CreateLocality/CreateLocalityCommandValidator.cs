using FluentValidation;
using DSEU.Application.Common.Constants;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.Commons;

namespace DSEU.Application.Modules.Commons.Localities.Commands.CreateLocality
{
    public class CreateLocalityCommandValidator : AbstractValidator<CreateLocalityCommand>
    {
        public CreateLocalityCommandValidator(IReadOnlyApplicationDbContext dbContext, ILocalizationService localizationService)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(locality => locality.Name)
                .NotEmpty()
                .MaximumLength(60)
                .WithName(localizationService[LocalizationKeys.PropertyNames.Name]);

            RuleFor(locality => locality.RegionId)
                 .NotEmpty()
                 .MustAsync(async (id, ct) => await dbContext.IsActiveAsync<Region>(id, ct))
                 .WithMessage(localizationService.StatusMustBeActive)
                 .WithName(localizationService[LocalizationKeys.PropertyNames.Region]);
        }
    }
}
