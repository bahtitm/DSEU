using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using DSEU.Application.Common.Constants;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.Commons;
using DSEU.Domain.Entities.Parties;

namespace DSEU.Application.Modules.Parties.Persons.Commands.EditPerson
{
    public class EditPersonCommandValidator : AbstractValidator<EditPersonCommand>
    {
        private readonly IReadOnlyApplicationDbContext dbContext;

        public EditPersonCommandValidator(IReadOnlyApplicationDbContext dbContext, ILocalizationService localizationService)
        {
            this.dbContext = dbContext;
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(p => p.FirstName).NotEmpty();
            RuleFor(p => p.LastName).NotEmpty();

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
        }

        private async Task<bool> TaxNumberWasModified(EditPersonCommand command, CancellationToken cancellationToken)
        {
            return await dbContext.Query<Person>().AnyAsync(p => p.Id == command.Id && p.TIN != command.TIN, cancellationToken);
        }

        private async Task<bool> TaxNumberNotDuplicated(string taxNumber, CancellationToken ct)
        {
            return await dbContext.Query<Person>().AllAsync(p => p.TIN != taxNumber);
        }

        private async Task<bool> RegionIdWasModified(EditPersonCommand command, CancellationToken cancellationToken)
        {
            return await dbContext.Query<Person>().AnyAsync(p => p.Id == command.Id && p.RegionId != command.RegionId, cancellationToken);
        }

        private async Task<bool> LocalityIdWasModified(EditPersonCommand command, CancellationToken cancellationToken)
        {
            return await dbContext.Query<Person>().AnyAsync(p => p.Id == command.Id && p.LocalityId != command.LocalityId, cancellationToken);
        }

        private async Task<bool> BankIdWasModified(EditPersonCommand command, CancellationToken cancellationToken)
        {
            return await dbContext.Query<Person>().AnyAsync(p => p.Id == command.Id && p.BankId != command.BankId, cancellationToken);
        }

    }
}
