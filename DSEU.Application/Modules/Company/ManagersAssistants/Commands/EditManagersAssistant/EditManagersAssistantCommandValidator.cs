using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using DSEU.Application.Common.Constants;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Dtos.Company;
using DSEU.Domain.Entities;
using DSEU.Domain.Entities.Company;

namespace DSEU.Application.Modules.Company.ManagersAssistants.Commands.EditManagersAssistant
{
    public class EditManagersAssistantCommandValidator : AbstractValidator<EditManagersAssistantCommand>
    {
        private readonly IReadOnlyApplicationDbContext dbContext;

        public EditManagersAssistantCommandValidator(IReadOnlyApplicationDbContext dbContext, ILocalizationService localizationService)
        {
            this.dbContext = dbContext;
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(p => p.Manager).NotEmpty();
            RuleFor(p => p.Assistant).NotEmpty();

            RuleFor(p => p)
                .Must(p => p.Manager?.Id != p.Assistant?.Id)
                .WithMessage(localizationService[LocalizationKeys.ManagersAssistantsKeys.ManagerAndAssistantCantBeSamePerson])
                .When(p => p.Manager != null && p.Assistant != null);

            RuleFor(p => p.Manager)
                .MustAsync(ActiveStatusPosition)
                .WithMessage(localizationService[LocalizationKeys.ManagersAssistantsKeys.ActiveManagerAssistantCantBeMoreThanOne])
                .When(p => p.Status == Status.Active)
                .When(p => p.Manager != null);
        }

        private async Task<bool> ActiveStatusPosition(EditManagersAssistantCommand command, EmployeeDto manager, CancellationToken cancellationToken)
        {
            return !await dbContext.Query<ManagersAssistant>().AnyAsync(m => m.Id != command.Id && m.ManagerId == manager.Id && m.Status == Status.Active);
        }
    }
}
