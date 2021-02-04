using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using DSEU.Application.Common.Constants;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.Commons;
using DSEU.Domain.Entities.Parties;

namespace DSEU.Application.Modules.Parties.Organizations.Companies.Commands.EditComany
{
    public class EditCompanyCommandValidator : AbstractValidator<EditCompanyCommand>
    {
        private readonly IReadOnlyApplicationDbContext dbContext;

        public EditCompanyCommandValidator(IReadOnlyApplicationDbContext dbContext, ILocalizationService localizationService)
        {
            this.dbContext = dbContext;
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(p => p).MustAsync(CanUpdate).WithMessage("Cant update system entity");

            RuleFor(p => p.Name).NotEmpty();

            When(p => !string.IsNullOrEmpty(p.TIN), () =>
            {
                WhenAsync(TaxNumberWasModified, () =>
                {
                    RuleFor(p => p.TIN)
                        .MustAsync(TaxNumberNotDuplicated)
                        .WithMessage(localizationService[LocalizationKeys.SharedKeys.ValueAlreadyExists]);
                });
            });

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

            When(p => p.BankId.HasValue, () =>
            {
                WhenAsync(BankIdWasModified, () =>
                 {
                     RuleFor(p => p.BankId.Value)
                         .MustAsync(async (bankId, ct) => await dbContext.IsActiveAsync<Bank>(bankId, ct))
                         .WithMessage(localizationService.StatusMustBeActive);
                 });
            });

            When(p => p.HeadCompanyId.HasValue, () =>
            {
                WhenAsync(HeadCompanyIdWasModified, () =>
                {
                    RuleFor(p => p.HeadCompanyId.Value)
                        .MustAsync(async (headCompanyId, ct) => await dbContext.IsActiveAsync<Domain.Entities.Parties.Company>(headCompanyId, ct))
                        .WithMessage(localizationService.StatusMustBeActive);

                    RuleFor(p => p.HeadCompanyId.Value)
                         .MustAsync(WithoutCircularNesting)
                         .WithMessage(localizationService[LocalizationKeys.SharedKeys.CircularNesting]);
                });
            });
        }

        private async Task<bool> TaxNumberWasModified(EditCompanyCommand command, CancellationToken cancellationToken)
        {
            return await dbContext.Query<Domain.Entities.Parties.Company>().AnyAsync(p => p.Id == command.Id && p.TIN != command.TIN, cancellationToken);
        }

        private async Task<bool> CanUpdate(EditCompanyCommand command, CancellationToken cancellationToken)
        {
            return await dbContext.Query<Domain.Entities.Parties.Company>().AnyAsync(p => p.Id == command.Id && !p.IsCardReadOnly, cancellationToken);
        }

        private async Task<bool> TaxNumberNotDuplicated(string taxNumber, CancellationToken ct)
        {
            return await dbContext.Query<Domain.Entities.Parties.Company>().AllAsync(p => p.TIN != taxNumber);
        }

        private async Task<bool> RegionIdWasModified(EditCompanyCommand command, CancellationToken cancellationToken)
        {
            return await dbContext.Query<Domain.Entities.Parties.Company>().AnyAsync(p => p.Id == command.Id && p.RegionId != command.RegionId, cancellationToken);
        }

        private async Task<bool> LocalityIdWasModified(EditCompanyCommand command, CancellationToken cancellationToken)
        {
            return await dbContext.Query<Domain.Entities.Parties.Company>().AnyAsync(p => p.Id == command.Id && p.LocalityId != command.LocalityId, cancellationToken);
        }

        private async Task<bool> BankIdWasModified(EditCompanyCommand command, CancellationToken cancellationToken)
        {
            return await dbContext.Query<Domain.Entities.Parties.Company>().AnyAsync(p => p.Id == command.Id && p.BankId != command.BankId, cancellationToken);
        }

        private async Task<bool> HeadCompanyIdWasModified(EditCompanyCommand command, CancellationToken cancellationToken)
        {
            return await dbContext.Query<Domain.Entities.Parties.Company>().AnyAsync(p => p.Id == command.Id && p.HeadCompanyId != command.HeadCompanyId, cancellationToken);
        }

        private async Task<bool> WithoutCircularNesting(EditCompanyCommand command, int parentId, CancellationToken token)
        {
            if (command.Id == parentId)
            {
                return false;
            }

            var Company = await dbContext.FindByIdAsync<Domain.Entities.Parties.Company>(parentId, token);

            var parentCompany = Company.HeadCompanyId;
            while (parentCompany.HasValue)
            {
                if (parentCompany.Value == command.Id)
                {
                    return false;
                }
                var parentCategory = await dbContext.Query<Domain.Entities.Parties.Company>().FirstOrDefaultAsync(p => p.Id == parentCompany.Value);
                parentCompany = parentCategory.HeadCompanyId;
            }
            return true;
        }
    }
}
