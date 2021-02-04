using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.Company;

namespace DSEU.Application.Modules.Company.JobTitles.Commands.CreateJobTitle
{
    public class CreateJobTitleCommandHandler : AsyncRequestHandler<CreateJobTitleCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public CreateJobTitleCommandHandler(IApplicationDbContext dbContext,IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected override async Task Handle(CreateJobTitleCommand request, CancellationToken cancellationToken)
        {
            JobTitle JobTitle = mapper.Map<JobTitle>(request);
            await dbContext.AddAsync(JobTitle, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
        }


    }
}
