using MediatR;

namespace DSEU.Application.Modules.Company.OurOrganization.OrganizationalUnits.Commands.DeleteOrganizationalUnit
{
    public class DeleteOrganizationalUnitCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteOrganizationalUnitCommand(int id)
        {
            Id = id;
        }
    }
}
