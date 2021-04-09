using AutoMapper;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.OurOrganization;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Company.OurOrganization.Branches.Commands.CreateBranch
{
    public class CreateBranchCommandHandler : AsyncRequestHandler<CreateBranchCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public CreateBranchCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected override async Task Handle(CreateBranchCommand request, CancellationToken cancellationToken)
        {
            var branch = mapper.Map<Branch>(request);
            await dbContext.AddAsync(branch, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
