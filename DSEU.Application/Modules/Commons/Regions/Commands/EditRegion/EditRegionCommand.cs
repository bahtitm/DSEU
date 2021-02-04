using MediatR;
using DSEU.Domain.Entities;

namespace DSEU.Application.Modules.Commons.Regions.Commands.EditRegion
{
    public class EditRegionCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        /// <summary>
        /// Состояние
        /// </summary>
        public Status Status { get; set; }
    }
}
