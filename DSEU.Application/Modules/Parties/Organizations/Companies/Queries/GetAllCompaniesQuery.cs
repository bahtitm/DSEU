using System.Collections.Generic;
using MediatR;
using DSEU.Application.Modules.Parties.Organizations.Companies.Models;

namespace DSEU.Application.Modules.Parties.Organizations.Companies.Queries
{
    public class GetAllCompaniesQuery : IRequest<IEnumerable<CompanyDto>>
    {
    }
}
