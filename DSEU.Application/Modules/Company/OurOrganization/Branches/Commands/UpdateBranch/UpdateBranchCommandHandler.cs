using AutoMapper;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.OurOrganization;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Company.OurOrganization.Branches.Commands.UpdateBranch
{
    public class UpdateBranchCommandHandler : AsyncRequestHandler<UpdateBranchCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public UpdateBranchCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected override async Task Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
        {
            var branch = await dbContext.FindByIdAsync<Branch>(request.Id);
            mapper.Map(request, branch);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
