using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.Commons;

namespace DSEU.Application.Modules.Commons.Countries.Commands.CreateCountry
{
    public class CreateCountryCommandHandler : AsyncRequestHandler<CreateCountryCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public CreateCountryCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected override async Task Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            Country country = mapper.Map<Country>(request);
            await dbContext.AddAsync(country, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
