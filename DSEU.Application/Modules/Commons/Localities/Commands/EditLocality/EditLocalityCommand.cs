using MediatR;
using DSEU.Domain.Entities;

namespace DSEU.Application.Modules.Commons.Localities.Commands.EditLocality
{
    public class EditLocalityCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RegionId { get; set; }
        /// <summary>
        /// Состояние
        /// </summary>
        public Status Status { get; set; }
    }
}
