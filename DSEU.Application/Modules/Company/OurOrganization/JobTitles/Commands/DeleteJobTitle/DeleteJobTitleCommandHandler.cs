using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.OurOrganization;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Company.OurOrganization.JobTitles.Commands.DeleteJobTitle
{
    public class DeleteJobTitleCommandHandler : AsyncRequestHandler<DeleteJobTitleCommand>
    {
        private readonly IApplicationDbContext dbContext;

        public DeleteJobTitleCommandHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        protected override async Task Handle(DeleteJobTitleCommand request, CancellationToken cancellationToken)
        {
            var jobTitle = await dbContext.FindByIdAsync<JobTitle>(request.Id, cancellationToken);
            dbContext.Set<JobTitle>().Remove(jobTitle);
            await dbContext.SaveChangesAsync();
        }
    }
}
