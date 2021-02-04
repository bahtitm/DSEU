using System.Collections.Generic;
using MediatR;
using DSEU.Application.Dtos.Company;

namespace DSEU.Application.Modules.Company.DepartmentMembers.Queries.GetAllDepartmentMembers
{
    public class GetAllDepartmentMembersQuery : IRequest<IEnumerable<DepartmentMemberDto>>
    {
        public int DepartmentId { get; }
        public GetAllDepartmentMembersQuery(int departmentId)
        {
            DepartmentId = departmentId;
        }
    }
}
