using MediatR;
using DSEU.Application.Modules.Parties.Organizations.Companies.Models;

namespace DSEU.Application.Modules.Parties.Organizations.Companies.Queries
{
    public class GetCompanyByIdQuery : IRequest<CompanyDto>
    {
        public GetCompanyByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
