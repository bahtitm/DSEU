using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using DSEU.Application.Common.Constants;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.Company;

namespace DSEU.Application.Modules.Company.Departments.Commands.EditDepartment
{
    public class EditDepartmentCommandValidator : AbstractValidator<EditDepartmentCommand>
    {
        private readonly IReadOnlyApplicationDbContext dbContext;

        public EditDepartmentCommandValidator(IReadOnlyApplicationDbContext dbContext, ILocalizationService localizationService)
        {
            this.dbContext = dbContext;
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(department => department.Name).NotEmpty();

            When(p => !string.IsNullOrEmpty(p.Code), () =>
            {
                RuleFor(bu => bu.Code)
                    .Matches(@"^[^\s]*$");

                WhenAsync(CodeWasModified, () =>
                {
                    RuleFor(bu => bu.Code)
                      .MustAsync(UniqCode)
                      .WithMessage(localizationService[LocalizationKeys.BusinessUnitKeys.BusinessUnitCodeAlreadyExists]);
                });
            });

            WhenAsync(BusinessUnitIdWasModified, () =>
            {
                RuleFor(department => department.BusinessUnitId)
                    .MustAsync(async (businessUnitId, ct) => await dbContext.IsActiveAsync<BusinessUnit>(businessUnitId, ct))
                    .WithMessage(localizationService.StatusMustBeActive);
            });

            When(p => p.HeadOfficeId.HasValue, () =>
            {
                WhenAsync(HeadOfficeIdWasModified, () =>
                {
                    RuleFor(department => department.HeadOfficeId.Value)
                        .MustAsync(async (headOfficeId, ct) => await dbContext.IsActiveAsync<Department>(headOfficeId, ct))
                        .WithMessage(localizationService.StatusMustBeActive);

                    RuleFor(department => department.HeadOfficeId.Value)
                        .MustAsync(WithoutCircularNesting)
                        .WithMessage(localizationService[LocalizationKeys.SharedKeys.CircularNesting]);
                });
            });


            When(p => p.ManagerId.HasValue, () =>
            {
                WhenAsync(ManagerIdWasModified, () =>
                {
                    RuleFor(department => department.ManagerId.Value)
                        .MustAsync(async (id, ct) => await dbContext.IsActiveAsync<Employee>(id, ct))
                        .WithMessage(localizationService.StatusMustBeActive);

                    RuleFor(department => department.ManagerId.Value)
                        .MustAsync(CanAssignManager)
                        .WithMessage(localizationService[LocalizationKeys.DepartmentKeys.ManagerAlreadyAssigned]);
                });
            });
        }

        private async Task<bool> CodeWasModified(EditDepartmentCommand command, CancellationToken cancellationToken)
        {
            return await dbContext.Query<Department>().AnyAsync(p => p.Id == command.Id && p.Code != command.Code, cancellationToken);
        }

        private async Task<bool> UniqCode(EditDepartmentCommand request, string code, CancellationToken cancellationToken)
        {
            return !await dbContext.Query<Department>()
                                   .AnyAsync(p => p.Code == code && p.BusinessUnitId == request.BusinessUnitId
                                   && p.Id != request.Id, cancellationToken);
        }

        private async Task<bool> BusinessUnitIdWasModified(EditDepartmentCommand command, CancellationToken cancellationToken)
        {
            return await dbContext.Query<Department>().AnyAsync(p => p.Id == command.Id && p.BusinessUnitId != command.BusinessUnitId, cancellationToken);
        }

        private async Task<bool> HeadOfficeIdWasModified(EditDepartmentCommand command, CancellationToken cancellationToken)
        {
            return await dbContext.Query<Department>().AnyAsync(p => p.Id == command.Id && p.HeadOfficeId != command.HeadOfficeId, cancellationToken);
        }

        private async Task<bool> WithoutCircularNesting(EditDepartmentCommand command, int parentId, CancellationToken ct)
        {
            if (command.Id == parentId)
            {
                return false;
            }

            var department = await dbContext.FindByIdAsync<Department>(parentId, ct);

            var parentDepartmentId = department.HeadOfficeId;
            while (parentDepartmentId.HasValue)
            {
                if (parentDepartmentId.Value == command.Id)
                {
                    return false;
                }
                var parentCategory = await dbContext.Query<Department>().FirstOrDefaultAsync(p => p.Id == parentDepartmentId.Value);
                parentDepartmentId = parentCategory.HeadOfficeId;
            }
            return true;
        }

        private async Task<bool> ManagerIdWasModified(EditDepartmentCommand command, CancellationToken cancellationToken)
        {
            return await dbContext.Query<Department>().AnyAsync(p => p.Id == command.Id && p.ManagerId != command.ManagerId, cancellationToken);
        }

        private async Task<bool> CanAssignManager(EditDepartmentCommand command, int managerId, CancellationToken cancellationToken)
        {
            return !await dbContext.Query<Department>().AnyAsync(p => p.ManagerId == managerId && p.Id != command.Id, cancellationToken);
        }
    }
}
