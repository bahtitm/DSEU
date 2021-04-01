using DSEU.Domain.Entities;
using MediatR;

namespace DSEU.Application.Modules.Company.OurOrganization.JobTitles.Commands.UpdateJobTitle
{
    public class UpdateJobTitleCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Status Status { get; set; }
    }
}
