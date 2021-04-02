using MediatR;

namespace DSEU.Application.Modules.Commons.Districts.Commands.DeleteDistrict
{
    public class DeleteDistrictCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteDistrictCommand(int id)
        {
            Id = id;
        }
    }
}
