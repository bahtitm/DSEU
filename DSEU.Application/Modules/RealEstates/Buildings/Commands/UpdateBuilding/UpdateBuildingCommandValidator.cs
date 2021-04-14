using FluentValidation;

namespace DSEU.Application.Modules.RealEstates.Buildings.Commands.UpdateBuilding
{
    public class UpdateBuildingCommandValidator : AbstractValidator<UpdateBuildingCommand>
    {
        public UpdateBuildingCommandValidator()
        {
            CascadeMode = CascadeMode.Stop;

        }
    }
}
