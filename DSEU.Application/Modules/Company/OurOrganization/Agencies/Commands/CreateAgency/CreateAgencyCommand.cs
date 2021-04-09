using DSEU.Domain.Entities;
using MediatR;

namespace DSEU.Application.Modules.Company.OurOrganization.Agencies.Commands.CreateAgency
{
    public class CreateAgencyCommand : IRequest
    {
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
