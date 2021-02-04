using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using DSEU.Application.Common.Constants;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.Company;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Application.Modules.Company.Employees.Commands.RegisterEmployee
{
    public class RegisterEmployeeCommandValidator : AbstractValidator<RegisterEmployeeCommand>
    {
        private readonly IReadOnlyApplicationDbContext dbContext;

        public RegisterEmployeeCommandValidator(IReadOnlyApplicationDbContext dbContext,
            ILocalizationService localizationService)
        {
            this.dbContext = dbContext;

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(user => user.Email)
                .EmailAddress()
                .MustAsync(UniqEmail)
                .WithMessage(localizationService[LocalizationKeys.EmployeeKeys.EmailMustBeUniq])
                .When(p => !string.IsNullOrEmpty(p.Email));

            RuleFor(user => user.Name).NotEmpty();

            RuleFor(p => p.JobTitleId)
                .MustAsync(async (id, ct) => await dbContext.IsActiveAsync<JobTitle>(id, ct))
                .WithMessage(localizationService.StatusMustBeActive);

            RuleFor(p => p.DepartmentId)
              .MustAsync(async (id, ct) => await dbContext.IsActiveAsync<Department>(id, ct))
              .WithMessage(localizationService.StatusMustBeActive);


            RuleFor(user => user)
               .Must(p => p.Password == p.ConfirmPassword)
               .WithMessage(localizationService[LocalizationKeys.EmployeeKeys.PasswordsDontMatch]);

            RuleFor(p => p.UserName)
                .NotEmpty()
                .MustAsync(async (userName, ct) => await dbContext.Query<Login>().AllAsync(p => p.LoginName != userName, ct))
                .WithMessage(localizationService[LocalizationKeys.EmployeeKeys.UserNameAlreadyExists]);

        }

        private async Task<bool> UniqEmail(string email, CancellationToken ct)
        => await dbContext.Query<Employee>().AllAsync(p => p.Email != email, ct);

    }
}
