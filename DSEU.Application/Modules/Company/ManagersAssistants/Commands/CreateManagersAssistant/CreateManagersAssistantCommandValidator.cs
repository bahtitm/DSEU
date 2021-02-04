using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using DSEU.Application.Common.Constants;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Dtos.Company;
using DSEU.Domain.Entities;
using DSEU.Domain.Entities.Company;

namespace DSEU.Application.Modules.Company.ManagersAssistants.Commands.CreateManagersAssistant
{
    public class CreateManagersAssistantCommandValidator : AbstractValidator<CreateManagersAssistantCommand>
    {
        private readonly IReadOnlyApplicationDbContext dbContext;
        public CreateManagersAssistantCommandValidator(IReadOnlyApplicationDbContext dbContext,
            ILocalizationService localizationService)
        {
            this.dbContext = dbContext;

            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(p => p.Manager).NotEmpty();
            RuleFor(p => p.Assistant).NotEmpty();

            RuleFor(p => p)
                .Must(p => p.Manager?.Id != p.Assistant?.Id)
                .WithMessage(localizationService[LocalizationKeys.ManagersAssistantsKeys.ManagerAndAssistantCantBeSamePerson]);

            RuleFor(p => p.Manager)
                .MustAsync(OnlyOneActiveStatusPosition)
                .WithMessage(localizationService[LocalizationKeys.ManagersAssistantsKeys.ActiveManagerAssistantCantBeMoreThanOne])
                .When(p => p.Manager != null);

        }

        private async Task<bool> OnlyOneActiveStatusPosition(CreateManagersAssistantCommand command, EmployeeDto manager, CancellationToken cancellationToken)
        {
            var activeManagerAssistantExists = await dbContext.Query<ManagersAssistant>().AnyAsync(m => m.ManagerId == manager.Id && m.Status == Status.Active);

            if (command.Status == Status.Active && activeManagerAssistantExists)
            {
                return false;

            }
            return true;
        }
    }
}
