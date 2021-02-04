using MediatR;
using DSEU.Domain.Entities;

namespace DSEU.Application.Modules.Commons.Regions.Commands.CreateRegion
{
    public class CreateRegionCommand : IRequest
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
        /// <summary>
        /// Состояние
        /// </summary>
        public Status Status { get; set; }
    }
}
