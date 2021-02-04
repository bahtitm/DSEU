using FluentValidation;
using Microsoft.EntityFrameworkCore;
using DSEU.Application.Common.Constants;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.Company;

namespace DSEU.Application.Modules.Company.DepartmentMembers.Commands.RemoveDepartmentMember
{
    public class RemoveDepartmentMemberCommandValidator : AbstractValidator<RemoveDepartmentMemberCommand>
    {
        public RemoveDepartmentMemberCommandValidator(IReadOnlyApplicationDbContext dbContext, ILocalizationService localizationService)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(p => p)
                .MustAsync(async (command, ct) => !await dbContext.Query<Employee>().AnyAsync(p => p.Id == command.EmployeeId && p.DepartmentId == command.DepartmentId))
                .WithMessage(localizationService[LocalizationKeys.DepartmentKeys.DepartmentMemberRemoveDenied]);

        }
    }
}
