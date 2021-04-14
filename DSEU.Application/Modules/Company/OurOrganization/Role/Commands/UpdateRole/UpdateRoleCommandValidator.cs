﻿using FluentValidation;

namespace DSEU.Application.Modules.Company.OurOrganization.Role.Commands.UpdateRole
{
    public class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
    {
        public UpdateRoleCommandValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(p => p.Name)
                .NotEmpty();

            RuleFor(p => p.UserClaimTypes)
                .NotEmpty();
        }
    }
}
