using FluentValidation;

namespace DSEU.Application.Modules.Commons.TerritorialUnits.Commands.UpdateTerritorialUnit
{
    public class UpdateTerritorialUnitCommandValidator : AbstractValidator<UpdateTerritorialUnitCommand>
    {
        public UpdateTerritorialUnitCommandValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(p => p.Name)
                .NotEmpty();

            RuleFor(p => p.TypeName)
                .NotEmpty();

            RuleFor(p => p.DistrictId)
                .NotEmpty();
        }
    }
}
