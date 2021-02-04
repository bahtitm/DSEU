using MediatR;
using DSEU.Domain.Entities;

namespace DSEU.Application.Modules.Commons.Localities.Commands.CreateLocality
{
    public class CreateLocalityCommand : IRequest
    {
        public string Name { get; set; }
        public int RegionId { get; set; }
        /// <summary>
        /// Состояние
        /// </summary>
        public Status Status { get; set; }
    }
}
