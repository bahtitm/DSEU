using FluentValidation;
using Microsoft.EntityFrameworkCore;
using DSEU.Application.Common.Constants;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.Company;

namespace DSEU.Application.Modules.Company.DepartmentMembers.Commands.AddDepartmentMember
{
    public class AddDepartmentMemberCommandValidator : AbstractValidator<AddDepartmentMemberCommand>
    {
        public AddDepartmentMemberCommandValidator(IReadOnlyApplicationDbContext dbContext, ILocalizationService localizationService)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(p => p)
                .MustAsync(async (command, ct) =>
                {
                    return !await dbContext.Query<Employee>().AnyAsync(p => p.Id == command.EmployeeId && p.DepartmentId == command.DepartmentId)&&
                           !await dbContext.Query<DepartmentRecipientLinks>().AnyAsync(p => p.MemberId == command.EmployeeId && p.GroupId == command.DepartmentId);
                })
                .WithMessage(localizationService[LocalizationKeys.DepartmentKeys.EmployeeAlreadyAssigned]);
        }


    }
}
