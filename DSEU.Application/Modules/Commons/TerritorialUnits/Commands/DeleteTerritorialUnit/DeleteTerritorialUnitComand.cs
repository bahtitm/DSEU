using MediatR;

namespace DSEU.Application.Modules.Commons.TerritorialUnits.Commands.DeleteTerritorialUnit
{
    public class DeleteTerritorialUnitComand : IRequest
    {
        public int Id { get; }

        public DeleteTerritorialUnitComand(int id)
        {
            Id = id;
        }
    }
}