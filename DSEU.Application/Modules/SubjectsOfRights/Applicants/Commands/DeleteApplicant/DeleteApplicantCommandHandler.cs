using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.SubjectsOfRights;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.SubjectsOfRights.Applicants.Commands.DeleteApplicant
{
    public class DeleteApplicantCommandHandler : AsyncRequestHandler<DeleteApplicantCommand>
    {
        private readonly IApplicationDbContext dbContext;

        public DeleteApplicantCommandHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        protected override async Task Handle(DeleteApplicantCommand request, CancellationToken cancellationToken)
        {
            var applicant = await dbContext.FindByIdAsync<Applicant>(request.id);
            dbContext.Set<Applicant>().Remove(applicant);
            await dbContext.SaveChangesAsync();
        }
    }
}
