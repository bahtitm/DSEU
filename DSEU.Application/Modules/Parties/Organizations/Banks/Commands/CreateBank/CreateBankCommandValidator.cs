using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using DSEU.Application.Common.Constants;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.Commons;
using DSEU.Domain.Entities.Parties;

namespace DSEU.Application.Modules.Parties.Organizations.Banks.Commands.CreateBank
{
    public class CreateBankCommandValidator : AbstractValidator<CreateBankCommand>
    {
        private readonly IReadOnlyApplicationDbContext dbContext;

        public CreateBankCommandValidator(IReadOnlyApplicationDbContext dbContext, ILocalizationService localizationService)
        {
            this.dbContext = dbContext;
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(p => p.Name).NotEmpty();

            RuleFor(p => p.RegionId.Value)
               .NotEmpty()
               .MustAsync(async (id, ct) => await dbContext.IsActiveAsync<Region>(id, ct))
               .WithMessage(localizationService.StatusMustBeActive)
               .When(p => p.RegionId.HasValue);

            RuleFor(p => p.LocalityId.Value)
                .NotEmpty()
                .MustAsync(async (id, ct) => await dbContext.IsActiveAsync<Locality>(id, ct))
                .WithMessage(localizationService.StatusMustBeActive)
                .MustAsync(async (command, id, ct) => await dbContext.IsCascadeBetween<Locality>(id, command.RegionId.Value, nameof(Locality.RegionId), ct))
                .WithMessage(localizationService.CascadeDependencyError)
                .When(p => p.LocalityId.HasValue);

            RuleFor(p => p.BIC)
                .MustAsync(BicNotDuplicated)
                .WithMessage(localizationService[LocalizationKeys.SharedKeys.ValueAlreadyExists])
                .When(p => !string.IsNullOrEmpty(p.BIC));

            RuleFor(p => p.TIN)
               .MustAsync(TaxNumberNotDuplicated)
               .WithMessage(localizationService[LocalizationKeys.SharedKeys.ValueAlreadyExists])
               .When(p => !string.IsNullOrEmpty(p.TIN));
        }


        private async Task<bool> BicNotDuplicated(string bic, CancellationToken ct)
        {
            return await dbContext.Query<Bank>().AllAsync(p => p.BIC != bic);
        }

        private async Task<bool> TaxNumberNotDuplicated(string taxNumber, CancellationToken ct)
        {
            return await dbContext.Query<Domain.Entities.Parties.Company>().AllAsync(p => p.TIN != taxNumber);
        }

    }
}
