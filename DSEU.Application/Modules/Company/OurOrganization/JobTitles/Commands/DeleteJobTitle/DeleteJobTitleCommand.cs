using MediatR;

namespace DSEU.Application.Modules.Company.OurOrganization.JobTitles.Commands.DeleteJobTitle
{
    public class DeleteJobTitleCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteJobTitleCommand(int id)
        {
            Id = id;
        }
    }
}
