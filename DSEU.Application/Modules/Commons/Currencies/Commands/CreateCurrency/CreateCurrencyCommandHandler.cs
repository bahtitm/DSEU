using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.Commons;

namespace DSEU.Application.Modules.Commons.Currencies.Commands.CreateCurrency
{
    public class CreateCurrencyCommandHandler : AsyncRequestHandler<CreateCurrencyCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public CreateCurrencyCommandHandler(IMapper mapper, IApplicationDbContext dbContext)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }

        protected override async Task Handle(CreateCurrencyCommand request, CancellationToken cancellationToken)
        {
            Currency currency = mapper.Map<Currency>(request);
            await dbContext.AddAsync(currency, cancellationToken);
            await dbContext.SaveChangesAsync();
        }
    }
}
