using MediatR;

namespace DSEU.Application.Modules.Company.BusinessUnits.Commands.RemoveBusinessUnit
{


    public class RemoveBusinessUnitCommand : IRequest
    {
        public int Id { get; set; }
    }
}
