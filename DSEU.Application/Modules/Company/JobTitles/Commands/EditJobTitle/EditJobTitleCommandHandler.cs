using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.Company;

namespace DSEU.Application.Modules.Company.JobTitles.Commands.EditJobTitle
{
    public class EditJobTitleCommandHandler : AsyncRequestHandler<EditJobTitleCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public EditJobTitleCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected override async Task Handle(EditJobTitleCommand request, CancellationToken cancellationToken)
        {
            var jobTitle = await dbContext.Set<JobTitle>().Include(p => p.Employees).FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
            mapper.Map(request, jobTitle);
            jobTitle.ReevaluateEmployeeDescription();
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
