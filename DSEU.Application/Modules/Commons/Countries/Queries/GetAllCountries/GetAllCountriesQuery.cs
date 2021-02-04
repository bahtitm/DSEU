using System.Collections.Generic;
using MediatR;
using DSEU.Application.Dtos.Commons;

namespace DSEU.Application.Modules.Commons.Countries.Queries.GetAllCountries
{
    public class GetAllCountriesQuery : IRequest<IEnumerable<CountryDto>>
    {
    }


}
