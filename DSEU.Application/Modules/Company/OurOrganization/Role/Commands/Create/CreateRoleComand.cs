using MediatR;

namespace DSEU.Application.Modules.Company.OurOrganization.Role.Commands.Create
{
    public class CreateComand:IRequest
    {
        public string Name { get; set; }
    }
}
