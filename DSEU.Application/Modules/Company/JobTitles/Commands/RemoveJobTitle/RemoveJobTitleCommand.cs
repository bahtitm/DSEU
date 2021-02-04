using MediatR;

namespace DSEU.Application.Modules.Company.JobTitles.Commands.RemoveJobTitle
{


    public class RemoveJobTitleCommand : IRequest
    {
        public int Id { get; set; }
    }
}
