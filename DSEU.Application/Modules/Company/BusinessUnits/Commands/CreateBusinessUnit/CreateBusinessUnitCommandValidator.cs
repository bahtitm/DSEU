using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using DSEU.Application.Common.Constants;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.Commons;
using DSEU.Domain.Entities.Company;
using DSEU.Domain.Entities.Parties;

namespace DSEU.Application.Modules.Company.BusinessUnits.Commands.CreateBusinessUnit
{
    public class CreateBusinessUnitCommandCommandValidator : AbstractValidator<CreateBusinessUnitCommand>
    {
        private readonly IReadOnlyApplicationDbContext dbContext;

        public CreateBusinessUnitCommandCommandValidator(IReadOnlyApplicationDbContext dbContext, ILocalizationService localizationService)
        {
            this.dbContext = dbContext;
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(bu => bu.Name).NotEmpty();
            RuleFor(bu => bu.LegalName).NotEmpty();

            When(p => !string.IsNullOrEmpty(p.Code), () =>
            {
                RuleFor(bu => bu.Code)
                       .Matches(@"^[^\s]*$")
                       .MustAsync(UniqCode)
                       .WithMessage(localizationService[LocalizationKeys.BusinessUnitKeys.BusinessUnitCodeAlreadyExists]);
            });

            RuleFor(bu => bu.RegionId)
                .NotEmpty()
                .MustAsync(async (id, ct) => await dbContext.IsActiveAsync<Region>(id.Value, ct))
                .WithMessage(localizationService.StatusMustBeActive)
                .When(p => p.RegionId.HasValue);

            RuleFor(bu => bu.LocalityId.Value)
                .NotEmpty()
                .MustAsync(async (id, ct) => await dbContext.IsActiveAsync<Locality>(id, ct))
                .WithMessage(localizationService.StatusMustBeActive)
                .MustAsync(async (command, id, ct) => await dbContext.IsCascadeBetween<Locality>(id, command.RegionId.Value, nameof(Locality.RegionId), ct))
                .WithMessage(localizationService.CascadeDependencyError)
                .When(bu => bu.LocalityId.HasValue);

            RuleFor(bu => bu.BankId.Value)
                .NotEmpty()
                .MustAsync(async (id, ct) => await dbContext.IsActiveAsync<Bank>(id, ct))
                .WithMessage(localizationService.StatusMustBeActive)
                .When(bu => bu.BankId.HasValue);


            RuleFor(bu => bu.TIN)
               .NotEmpty()
               .MustAsync(TaxNumberExists)
               .WithMessage(localizationService[LocalizationKeys.BusinessUnitKeys.TaxNumberAlreadyExists])
               .When(p => !string.IsNullOrEmpty(p.TIN));

            RuleFor(bu => bu.CEO.Value)
                .NotEmpty()
                .MustAsync(async (id, ct) => await dbContext.IsActiveAsync<Employee>(id, ct))
                .WithMessage(localizationService.StatusMustBeActive)
                .MustAsync(CanCeoAppointed)
                .WithMessage(localizationService[LocalizationKeys.BusinessUnitKeys.CeoAlreadyAssigned])
                .When(bu => bu.CEO.HasValue);
        }

        private async Task<bool> TaxNumberExists(string taxNumber, CancellationToken cancellationToken)
        {
            return !await dbContext.Query<BusinessUnit>().AnyAsync(p => p.TIN == taxNumber, cancellationToken);
        }

        private async Task<bool> UniqCode(string code, CancellationToken cancellationToken)
        {
            return !await dbContext.Query<BusinessUnit>().AnyAsync(p => p.Code == code, cancellationToken);
        }

        private async Task<bool> CanCeoAppointed(int ceo, CancellationToken cancellationToken)
        {
            return !await dbContext.Query<BusinessUnit>()
                .AnyAsync(p => p.CEO == ceo, cancellationToken);
        }
    }
}
