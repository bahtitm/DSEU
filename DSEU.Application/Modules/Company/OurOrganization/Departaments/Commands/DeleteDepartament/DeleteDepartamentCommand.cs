using MediatR;

namespace DSEU.Application.Modules.Company.OurOrganization.Departaments.Commands.DeleteDepartament
{
    public record DeleteDepartamentCommand(int id) : IRequest;
}
