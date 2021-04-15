using AutoMapper;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.SubjectsOfRights;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.SubjectsOfRights.Applicants.Commands.CreateApplicant
{
    public class CreateApplicantCommandHandler : AsyncRequestHandler<CreateApplicantCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public CreateApplicantCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected override async Task Handle(CreateApplicantCommand request, CancellationToken cancellationToken)
        {
            var applicant = mapper.Map<Applicant>(request);
            await dbContext.AddAsync(applicant);
            await dbContext.SaveChangesAsync();
        }
    }
}
