using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Modules.Parties.Organizations.Banks.Models;
using DSEU.Domain.Entities.Parties;

namespace DSEU.Application.Modules.Parties.Organizations.Banks.Queries.Handlers
{
    public class GetAllBanksQueryHandler :
        IRequestHandler<GetAllBanksQuery, IEnumerable<BankDto>>,
        IRequestHandler<GetBankByIdQuery, BankDto>
    {
        private readonly IReadOnlyApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetAllBanksQueryHandler(IReadOnlyApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<BankDto>> Handle(GetAllBanksQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Query<Bank>().ProjectTo<BankDto>(mapper.ConfigurationProvider));
        }

        public async Task<BankDto> Handle(GetBankByIdQuery request, CancellationToken cancellationToken)
        {
            var bank = await dbContext.Query<Bank>().FirstOrDefaultAsync(p => p.Id == request.Id);
            return mapper.Map<BankDto>(bank);
        }
    }
}
