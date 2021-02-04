using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using DSEU.Application.Common.Constants;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.Company;

namespace DSEU.Application.Modules.Company.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentCommandValidator : AbstractValidator<CreateDepartmentCommand>
    {
        private readonly IReadOnlyApplicationDbContext dbContext;

        public CreateDepartmentCommandValidator(IReadOnlyApplicationDbContext dbContext, ILocalizationService localizationService)
        {
            this.dbContext = dbContext;

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(department => department.Name).NotEmpty();

            When(p => !string.IsNullOrEmpty(p.Code), () =>
            {
                RuleFor(department => department.Code)
                       .Matches(@"^[^\s]*$")
                       .MustAsync(UniqCode)
                       .WithMessage(localizationService[LocalizationKeys.DepartmentKeys.DepartmentCodeAlreadyExists]);
            });

            RuleFor(department => department.BusinessUnitId)
                .NotEmpty()
                .MustAsync(async (id, ct) => await dbContext.IsActiveAsync<BusinessUnit>(id, ct))
                .WithMessage(localizationService.StatusMustBeActive);

            RuleFor(department => department.HeadOfficeId.Value)
               .NotEmpty()
               .MustAsync(async (id, ct) => await dbContext.IsActiveAsync<Department>(id, ct))
               .WithMessage(localizationService.StatusMustBeActive)
               .MustAsync(async (command, id, ct) => await dbContext.IsCascadeBetween<Department>(id, command.BusinessUnitId, nameof(Department.BusinessUnitId), ct))
               .WithMessage(localizationService.CascadeDependencyError)
               .When(department => department.HeadOfficeId.HasValue);

            RuleFor(department => department.ManagerId.Value)
               .NotEmpty()
               .MustAsync(async (id, ct) => await dbContext.IsActiveAsync<Employee>(id, ct))
               .WithMessage(localizationService.StatusMustBeActive)
               .MustAsync(ManagerAlreadyAssignedAsync)
               .WithMessage(localizationService[LocalizationKeys.DepartmentKeys.ManagerAlreadyAssigned])
               .When(department => department.ManagerId.HasValue);

        }

        private async Task<bool> UniqCode(CreateDepartmentCommand command, string code, CancellationToken cancellationToken)
        {
            return !await dbContext.Query<Department>()
                                   .AnyAsync(p => p.Code == code && p.BusinessUnitId == command.BusinessUnitId, cancellationToken);
        }

        private async Task<bool> ManagerAlreadyAssignedAsync(int managerId, CancellationToken cancellationToken)
        {
            return !await dbContext.Query<Department>()
                .AnyAsync(p => p.ManagerId == managerId, cancellationToken);
        }
    }
}
