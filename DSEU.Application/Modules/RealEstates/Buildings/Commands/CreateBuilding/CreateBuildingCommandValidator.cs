using FluentValidation;

namespace DSEU.Application.Modules.RealEstates.Buildings.Commands.CreateBuilding
{
    public class CreateBuildingCommandValidator : AbstractValidator<CreateBuildingCommand>
    {
        public CreateBuildingCommandValidator()
        {
            CascadeMode = CascadeMode.Stop;

        }
    }
}
