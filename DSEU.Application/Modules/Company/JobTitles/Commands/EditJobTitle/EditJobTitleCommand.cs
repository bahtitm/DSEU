using MediatR;
using DSEU.Domain.Entities;

namespace DSEU.Application.Modules.Company.JobTitles.Commands.EditJobTitle
{


    public class EditJobTitleCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Состояние
        /// </summary>
        public Status Status { get; set; }
    }
}
