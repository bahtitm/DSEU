using AutoMapper;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.OurOrganization;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Company.OurOrganization.JobTitles.Commands.UpdateJobTitle
{
    public class UpdateJobTitleCommandHandler : AsyncRequestHandler<UpdateJobTitleCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public UpdateJobTitleCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected override async Task Handle(UpdateJobTitleCommand request, CancellationToken cancellationToken)
        {
            var jobTitle = await dbContext.FindByIdAsync<JobTitle>(request.Id, cancellationToken);
            mapper.Map(request, jobTitle);
            await dbContext.SaveChangesAsync();
        }
    }
}
