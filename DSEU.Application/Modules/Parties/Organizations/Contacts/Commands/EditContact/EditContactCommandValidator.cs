using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.Parties;

namespace DSEU.Application.Modules.Parties.Organizations.Contacts.Commands.EditContact
{
    public class EditContactCommandValidator : AbstractValidator<EditContactCommand>
    {
        private readonly IReadOnlyApplicationDbContext dbContext;
        public EditContactCommandValidator(IReadOnlyApplicationDbContext dbContext, ILocalizationService localizationService)
        {
            this.dbContext = dbContext;
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(p => p.Name).NotEmpty();

            
                WhenAsync(CompanyIdWasModified, () =>
                {
                    RuleFor(p => p.CompanyId)
                        .MustAsync(async (regionId, ct) => await dbContext.IsActiveAsync<CompanyBase>(regionId, ct))
                        .WithMessage(localizationService.StatusMustBeActive);
                });
        }

        private async Task<bool> CompanyIdWasModified(EditContactCommand command, CancellationToken cancellationToken)
        {
            return await dbContext.Query<Contact>().AnyAsync(p => p.Id == command.Id && p.CompanyId != command.CompanyId, cancellationToken);
        }
    }
}
