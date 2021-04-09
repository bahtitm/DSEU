using DSEU.Domain.Entities;
using MediatR;

namespace DSEU.Application.Modules.Company.OurOrganization.Departaments.Commands.CreateDepartament
{
    public class CreateDepartamentCommand : IRequest
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Состояние
        /// </summary>
        public Status Status { get; set; }
        public int AgencyId { get; set; }
    }
}
