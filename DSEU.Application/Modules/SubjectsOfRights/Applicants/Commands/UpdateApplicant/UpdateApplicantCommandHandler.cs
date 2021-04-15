using AutoMapper;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.SubjectsOfRights;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.SubjectsOfRights.Applicants.Commands.UpdateApplicant
{
    public class UpdateApplicantCommandHandler : AsyncRequestHandler<UpdateApplicantCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public UpdateApplicantCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected override async Task Handle(UpdateApplicantCommand request, CancellationToken cancellationToken)
        {
            var applicant = await dbContext.FindByIdAsync<Applicant>(request.Id);
            mapper.Map(request, applicant);
            await dbContext.SaveChangesAsync();
        }
    }
}
