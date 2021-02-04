using MediatR;
using DSEU.Domain.Entities;

namespace DSEU.Application.Modules.Company.JobTitles.Commands.CreateJobTitle
{


    public class CreateJobTitleCommand : IRequest
    {
        public string Name { get; set; }
        /// <summary>
        /// Состояние
        /// </summary>
        public Status Status { get; set; }
    }
}
