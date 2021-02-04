using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Dtos.Company;
using DSEU.Domain.Entities.Company;

namespace DSEU.Application.Modules.Company.BusinessUnits.Queries.GetBusinessUnitsById
{
    public class GetBusinessUnitsByIdQueryHandler : IRequestHandler<GetBusinessUnitsByIdQuery, BusinessUnitDto>
    {
        private readonly IReadOnlyApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetBusinessUnitsByIdQueryHandler(IReadOnlyApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<BusinessUnitDto> Handle(GetBusinessUnitsByIdQuery request, CancellationToken cancellationToken)
        {
            var businessUnit = await dbContext.Query<BusinessUnit>().FirstOrDefaultAsync(bu => bu.Id == request.Id);

            return  mapper.Map<BusinessUnitDto>(businessUnit);
        }
    }
}
