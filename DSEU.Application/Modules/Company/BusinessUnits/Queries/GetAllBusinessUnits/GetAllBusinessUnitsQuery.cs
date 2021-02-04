using MediatR;
using System.Collections.Generic;
using DSEU.Application.Dtos.Company;

namespace DSEU.Application.Modules.Company.BusinessUnits.Queries.GetAllBusinessUnits
{
    public class GetAllBusinessUnitsQuery : IRequest<IEnumerable<BusinessUnitDto>>
    {
    }
}
