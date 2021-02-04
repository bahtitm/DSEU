using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.Company;

namespace DSEU.Application.Modules.Company.JobTitles.Commands.RemoveJobTitle
{
    public class RemoveJobTitleCommandHandler : AsyncRequestHandler<RemoveJobTitleCommand>
    {
        private readonly IApplicationDbContext dbContext;

        public RemoveJobTitleCommandHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        protected override async Task Handle(RemoveJobTitleCommand request, CancellationToken cancellationToken)
        {
            var jobTitle = await dbContext.Set<JobTitle>().Include(p => p.Employees).FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
            jobTitle.Remove();
            dbContext.Set<JobTitle>().Remove(jobTitle);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
