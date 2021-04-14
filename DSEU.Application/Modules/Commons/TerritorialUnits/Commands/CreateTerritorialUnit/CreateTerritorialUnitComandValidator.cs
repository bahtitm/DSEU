using FluentValidation;

namespace DSEU.Application.Modules.Commons.TerritorialUnits.Commands.CreateTerritorialUnit
{
    public class CreateTerritorialUnitComandValidator : AbstractValidator<CreateTerritorialUnitComand>
    {
        public CreateTerritorialUnitComandValidator()
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
