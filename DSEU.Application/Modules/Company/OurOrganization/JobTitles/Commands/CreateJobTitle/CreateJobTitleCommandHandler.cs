using AutoMapper;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.OurOrganization;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Company.OurOrganization.JobTitles.Commands.CreateJobTitle
{
    public class CreateJobTitleCommandHandler : AsyncRequestHandler<CreateJobTitleCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public CreateJobTitleCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected override async Task Handle(CreateJobTitleCommand request, CancellationToken cancellationToken)
        {
            var jobTitle = mapper.Map<JobTitle>(request);
            await dbContext.AddAsync(jobTitle, cancellationToken);
            await dbContext.SaveChangesAsync();
        }
    }
}
