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

namespace DSEU.Application.Modules.Company.BusinessUnits.Commands.EditBusinessUnit
{
    public class EditBusinessUnitCommandValidator : AbstractValidator<EditBusinessUnitCommand>
    {
        private readonly IReadOnlyApplicationDbContext dbContext;

        public EditBusinessUnitCommandValidator(IReadOnlyApplicationDbContext dbContext, ILocalizationService localizationService)
        {
            this.dbContext = dbContext;

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(bu => bu.Name).NotEmpty();
            RuleFor(bu => bu.LegalName).NotEmpty();

            When(p => !string.IsNullOrEmpty(p.Code), () =>
            {
                RuleFor(bu => bu.Code)
                    .Matches(@"^[^\s]*$");

                WhenAsync(CodeWasModified, () =>
                {
                    RuleFor(bu => bu.Code)
                      .MustAsync(UniqCode)
                      .WithMessage(localizationService[LocalizationKeys.BusinessUnitKeys.BusinessUnitCodeAlreadyExists]);
                });
            });

            WhenAsync(RegionIdWasModified, () =>
            {
                RuleFor(bu => bu.RegionId)
                    .MustAsync(async (regionId, ct) => await dbContext.IsActiveAsync<Region>(regionId, ct))
                    .WithMessage(localizationService.StatusMustBeActive);
            });

            When(p => !string.IsNullOrEmpty(p.TIN), () =>
            {
                WhenAsync(TaxNumberWasModified, () =>
                {
                    RuleFor(bu => bu.TIN)
                        .MustAsync(TaxNumberFree)
                        .WithMessage(localizationService[LocalizationKeys.SharedKeys.ValueAlreadyExists]);
                });
            });

            When(p => p.LocalityId.HasValue, () =>
            {
                WhenAsync(LocalityIdWasModified, () =>
                {
                    RuleFor(bu => bu.LocalityId.Value)
                       .MustAsync(async (localityId, ct) => await dbContext.IsActiveAsync<Locality>(localityId, ct))
                       .WithMessage(localizationService.StatusMustBeActive)
                       .WhenAsync(LocalityIdWasModified);
                });

                RuleFor(bu => bu.LocalityId.Value)
                    .MustAsync(async (command, id, ct) => await dbContext.IsCascadeBetween<Locality>(id, command.RegionId, nameof(Locality.RegionId), ct))
                    .WithMessage(localizationService.CascadeDependencyError);
            });

            When(p => p.BankId.HasValue, () =>
            {
                WhenAsync(BankWasModified, () =>
                {
                    RuleFor(bu => bu.BankId.Value)
                        .MustAsync(async (bankId, ct) => await dbContext.IsActiveAsync<Bank>(bankId, ct))
                        .WithMessage(localizationService.StatusMustBeActive);
                });
            });

            When(bu => bu.CEO.HasValue, () =>
            {
                WhenAsync(CeoWasModified, () =>
                {
                    RuleFor(bu => bu.CEO.Value)
                        .NotEmpty()
                        .MustAsync(async (ceo, ct) => await dbContext.IsActiveAsync<Employee>(ceo, ct))
                        .WithMessage(localizationService.StatusMustBeActive);

                    RuleFor(bu => bu.CEO.Value)
                        .MustAsync(CanAssignCeo)
                        .WithMessage(localizationService[LocalizationKeys.BusinessUnitKeys.CeoAlreadyAssigned]);
                });
            });
        }

        private async Task<bool> CodeWasModified(EditBusinessUnitCommand command, CancellationToken cancellationToken)
        {
            return await dbContext.Query<BusinessUnit>().AnyAsync(p => p.Id == command.Id && p.Code != command.Code, cancellationToken);
        }

        private async Task<bool> UniqCode(EditBusinessUnitCommand request, string code, CancellationToken cancellationToken)
        {
            return !await dbContext.Query<BusinessUnit>().AnyAsync(p => p.Code == code && p.Id != request.Id, cancellationToken);
        }

        private async Task<bool> RegionIdWasModified(EditBusinessUnitCommand command, CancellationToken cancellationToken)
        {
            return await dbContext.Query<BusinessUnit>().AnyAsync(p => p.Id == command.Id && p.RegionId != command.RegionId, cancellationToken);
        }

        private async Task<bool> TaxNumberWasModified(EditBusinessUnitCommand command, CancellationToken cancellationToken)
        {
            return await dbContext.Query<BusinessUnit>().AnyAsync(p => p.Id == command.Id && p.TIN != command.TIN, cancellationToken);
        }

        private async Task<bool> TaxNumberFree(EditBusinessUnitCommand request, string taxNumber, CancellationToken cancellationToken)
        {
            return !await dbContext.Query<BusinessUnit>()
                .AnyAsync(p => p.TIN == taxNumber && p.Id != request.Id, cancellationToken);

        }

        private async Task<bool> LocalityIdWasModified(EditBusinessUnitCommand command, CancellationToken cancellationToken)
        {
            return await dbContext.Query<BusinessUnit>().AnyAsync(p => p.Id == command.Id && p.LocalityId != command.LocalityId, cancellationToken);
        }

        private async Task<bool> BankWasModified(EditBusinessUnitCommand command, CancellationToken cancellationToken)
        {
            return await dbContext.Query<BusinessUnit>().AnyAsync(p => p.Id == command.Id && p.BankId != command.BankId, cancellationToken);
        }

        private async Task<bool> CeoWasModified(EditBusinessUnitCommand command, CancellationToken cancellationToken)
        {
            return await dbContext.Query<BusinessUnit>().AnyAsync(p => p.Id == command.Id && p.CEO != command.CEO, cancellationToken);
        }

        private async Task<bool> CanAssignCeo(EditBusinessUnitCommand request, int ceo, CancellationToken cancellationToken)
        {
            return !await dbContext.Query<BusinessUnit>()
                .AnyAsync(p => p.CEO == ceo && p.Id != request.Id, cancellationToken);
        }
    }
}
