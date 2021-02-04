using FluentValidation;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.Parties;

namespace DSEU.Application.Modules.Parties.Organizations.Contacts.Commands.CreateContact
{
    public class CreateContactCommandValidator : AbstractValidator<CreateContactCommand>
    {
        public CreateContactCommandValidator(IReadOnlyApplicationDbContext dbContext, ILocalizationService localizationService)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(p => p.Name).NotEmpty();

            RuleFor(p => p.CompanyId)
               .NotEmpty()
               .MustAsync(async (id, ct) => await dbContext.IsActiveAsync<CompanyBase>(id, ct))
               .WithMessage(localizationService.StatusMustBeActive);
        }
    }
}
