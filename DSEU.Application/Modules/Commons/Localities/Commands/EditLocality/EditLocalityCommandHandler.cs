using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.Commons;

namespace DSEU.Application.Modules.Commons.Localities.Commands.EditLocality
{
    public class EditLocalityCommandHandler : AsyncRequestHandler<EditLocalityCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public EditLocalityCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected override async Task Handle(EditLocalityCommand request, CancellationToken cancellationToken)
        {
            var locality = await dbContext.FindByIdAsync<Locality>(request.Id, cancellationToken);

            mapper.Map(request, locality);

            await dbContext.SaveChangesAsync();
        }
    }
}
