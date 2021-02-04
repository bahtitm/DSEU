using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.Commons;

namespace DSEU.Application.Modules.Commons.Localities.Commands.CreateLocality
{
    public class CreateLocalityCommandHandler : AsyncRequestHandler<CreateLocalityCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public CreateLocalityCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected override async Task Handle(CreateLocalityCommand request, CancellationToken cancellationToken)
        {
            var locality = mapper.Map<Locality>(request);
            await dbContext.AddAsync(locality, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
