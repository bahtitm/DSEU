using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using DSEU.Application.Common.Constants;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.Commons;

namespace DSEU.Application.Modules.Commons.Regions.Commands.EditRegion
{
    public class EditRegionCommandValidator : AbstractValidator<EditRegionCommand>
    {
        private readonly IReadOnlyApplicationDbContext dbContext;

        public EditRegionCommandValidator(ILocalizationService localizationService,
            IReadOnlyApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;

            WhenAsync(CountryIdWasModified, () =>
            {
                 RuleFor(region => region.CountryId)
                    .NotEmpty()
                    .MustAsync(async (countryId, ct) => await dbContext.IsActiveAsync<Country>(countryId, ct))
                    .WithMessage(localizationService.StatusMustBeActive)
                    .WithName(localizationService[LocalizationKeys.PropertyNames.Country]);
             });


            RuleFor(region => region.Name)
                .NotEmpty()
                .MaximumLength(60)
                .WithName(localizationService[LocalizationKeys.PropertyNames.Name]);
        }

        private async Task<bool> CountryIdWasModified(EditRegionCommand command, CancellationToken cancellationToken)
        {
            return await dbContext.Query<Region>().AnyAsync(p => p.Id == command.Id && p.CountryId != command.CountryId, cancellationToken);
        }
    }
}
