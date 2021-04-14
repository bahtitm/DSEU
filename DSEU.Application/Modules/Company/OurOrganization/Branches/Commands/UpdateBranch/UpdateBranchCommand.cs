using DSEU.Domain.Entities;
using MediatR;

namespace DSEU.Application.Modules.Company.OurOrganization.Branches.Commands.UpdateBranch
{
    public class UpdateBranchCommand : IRequest
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
        public int DepartamentId { get; set; }
        public int DistrictId { get; set; }
    }
}
