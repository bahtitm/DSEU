using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Modules.Parties.Organizations.Banks.Models;
using DSEU.Domain.Entities.Parties;

namespace DSEU.Application.Modules.Parties.Organizations.Banks.Commands.EditBank
{
    public class EditBankCommandHandler : IRequestHandler<EditBankCommand, BankDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public EditBankCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<BankDto> Handle(EditBankCommand request, CancellationToken cancellationToken)
        {
            var bank = await dbContext.FindByIdAsync<Bank>(request.Id, cancellationToken);
            mapper.Map(request, bank);
            await dbContext.SaveChangesAsync();
            return mapper.Map<BankDto>(bank);
        }
    }
}
