using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using DSEU.Application.Dtos.Company;

namespace DSEU.Application.Modules.Company.BusinessUnits.Queries.GetBusinessUnitsById
{
    public class GetBusinessUnitsByIdQuery : IRequest<BusinessUnitDto>
    {
        public GetBusinessUnitsByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }

    }
}
