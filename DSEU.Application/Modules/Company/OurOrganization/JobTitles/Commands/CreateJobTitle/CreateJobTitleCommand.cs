using DSEU.Domain.Entities;
using MediatR;

namespace DSEU.Application.Modules.Company.OurOrganization.JobTitles.Commands.CreateJobTitle
{
    public class CreateJobTitleCommand : IRequest
    {
        public string Name { get; set; }
        public Status Status { get; set; }
    }
}
