using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using DSEU.Application.Common.Constants;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.Commons;
using DSEU.Domain.Entities.Parties;

namespace DSEU.Application.Modules.Parties.Organizations.Banks.Commands.EditBank
{
    public class EditBankCommandValidator : AbstractValidator<EditBankCommand>
    {
        private readonly IReadOnlyApplicationDbContext dbContext;

        public EditBankCommandValidator(IReadOnlyApplicationDbContext dbContext, ILocalizationService localizationService)
        {
            this.dbContext = dbContext;
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(p => p.Name).NotEmpty();

            When(p => p.RegionId.HasValue, () =>
            {
                WhenAsync(RegionIdWasModified, () =>
                {
                    RuleFor(p => p.RegionId.Value)
                        .MustAsync(async (regionId, ct) => await dbContext.IsActiveAsync<Region>(regionId, ct))
                        .WithMessage(localizationService.StatusMustBeActive);
                });
            });

            When(p => p.LocalityId.HasValue, () =>
            {
                WhenAsync(LocalityIdWasModified, () =>
                {
                    RuleFor(p => p.LocalityId.Value)
                        .MustAsync(async (localityId, ct) => await dbContext.IsActiveAsync<Locality>(localityId, ct))
                        .WithMessage(localizationService.StatusMustBeActive);

                    RuleFor(p => p.LocalityId.Value)
                        .MustAsync(async (command, id, ct) => await dbContext.IsCascadeBetween<Locality>(id, command.RegionId.Value, nameof(Locality.RegionId), ct))
                        .WithMessage(localizationService.CascadeDependencyError);

                });
            });

            When(p => !string.IsNullOrEmpty(p.TIN), () =>
            {
                WhenAsync(TaxNumberWasModified, () =>
                {
                    RuleFor(p => p.TIN)
                        .MustAsync(TaxNumberNotDuplicated)
                        .WithMessage(localizationService[LocalizationKeys.SharedKeys.ValueAlreadyExists]);
                });
            });

            When(p => !string.IsNullOrEmpty(p.BIC), () =>
            {
                WhenAsync(BICWasModified, () =>
                {
                    RuleFor(p => p.BIC)
                        .MustAsync(IdentifierNotDuplicated)
                        .WithMessage(localizationService[LocalizationKeys.SharedKeys.ValueAlreadyExists]);
                });
            });
        }

        private async Task<bool> TaxNumberWasModified(EditBankCommand command, CancellationToken cancellationToken)
        {
            return await dbContext.Query<Bank>().AnyAsync(p => p.Id == command.Id && p.TIN != command.TIN, cancellationToken);
        }

        private async Task<bool> TaxNumberNotDuplicated(string taxNumber, CancellationToken ct)
        {
            return await dbContext.Query<Domain.Entities.Parties.Company>().AllAsync(p => p.TIN != taxNumber);
        }

        private async Task<bool> RegionIdWasModified(EditBankCommand command, CancellationToken cancellationToken)
        {
            return await dbContext.Query<Bank>().AnyAsync(p => p.Id == command.Id && p.RegionId != command.RegionId, cancellationToken);
        }

        private async Task<bool> LocalityIdWasModified(EditBankCommand command, CancellationToken cancellationToken)
        {
            return await dbContext.Query<Bank>().AnyAsync(p => p.Id == command.Id && p.LocalityId != command.LocalityId, cancellationToken);
        }

        private async Task<bool> BICWasModified(EditBankCommand command, CancellationToken cancellationToken)
        {
            return await dbContext.Query<Bank>().AnyAsync(p => p.Id == command.Id && p.LocalityId != command.LocalityId, cancellationToken);
        }

        private async Task<bool> IdentifierNotDuplicated(string bic, CancellationToken ct)
        {
            return await dbContext.Query<Bank>().AllAsync(p => p.BIC != bic);
        }
    }
}
