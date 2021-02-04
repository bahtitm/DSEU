using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Modules.Parties.Organizations.Banks.Models;
using DSEU.Domain.Entities.Parties;

namespace DSEU.Application.Modules.Parties.Organizations.Banks.Commands.CreateBank
{
    public class CreateBankCommandHandler : IRequestHandler<CreateBankCommand, BankDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public CreateBankCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<BankDto> Handle(CreateBankCommand request, CancellationToken cancellationToken)
        {
            var bank = mapper.Map<Bank>(request);
            await dbContext.AddAsync(bank);
            await dbContext.SaveChangesAsync();
            return mapper.Map<BankDto>(bank);
        }
    }
}
