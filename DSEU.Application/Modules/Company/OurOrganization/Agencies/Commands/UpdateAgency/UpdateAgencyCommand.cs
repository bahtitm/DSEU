using DSEU.Domain.Entities;
using MediatR;

namespace DSEU.Application.Modules.Company.OurOrganization.Agencies.Commands.UpdateAgency
{
    public class UpdateAgencyCommand : IRequest
    {
        public int Id { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Состояние
        /// </summary>
        public Status Status { get; set; }
    }
}
