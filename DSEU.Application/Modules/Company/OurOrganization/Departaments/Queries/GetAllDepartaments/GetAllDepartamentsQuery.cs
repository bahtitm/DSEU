using DSEU.Application.Modules.Company.OurOrganization.Departaments.Dtos;
using MediatR;
using System.Collections.Generic;

namespace DSEU.Application.Modules.Company.OurOrganization.Departaments.Queries.GetAllDepartaments
{
    public record GetAllDepartamentsQuery : IRequest<IEnumerable<DepartamentDto>>;
}
