using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.Commons;

namespace DSEU.Application.Modules.Commons.Currencies.Commands.EditCurrency
{
    public class EditCurrencyCommandHandler : AsyncRequestHandler<EditCurrencyCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public EditCurrencyCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected override async Task Handle(EditCurrencyCommand request, CancellationToken cancellationToken)
        {
            var country = await dbContext.FindByIdAsync<Currency>(request.Id, cancellationToken);

            mapper.Map(request, country);

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
