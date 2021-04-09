using DSEU.Application.Modules.Company.OurOrganization.Departaments.Dtos;
using MediatR;

namespace DSEU.Application.Modules.Company.OurOrganization.Departaments.Queries.GetDepartamentDetail
{
    public record GetDepartamentDetailQuery(int id) : IRequest<DepartamentDto>;
}
