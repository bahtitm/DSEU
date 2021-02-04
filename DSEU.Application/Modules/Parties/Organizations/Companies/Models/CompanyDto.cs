using DSEU.Application.Common.Mapping;
using DSEU.Application.Modules.Parties.Shared.Models;

namespace DSEU.Application.Modules.Parties.Organizations.Companies.Models
{
    public class CompanyDto : CompanyBaseDto, IMapFrom<Domain.Entities.Parties.Company>
    {
        
    }
}
