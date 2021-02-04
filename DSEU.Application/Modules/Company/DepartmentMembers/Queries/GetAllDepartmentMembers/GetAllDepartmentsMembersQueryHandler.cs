using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Dtos.Company;
using DSEU.Domain.Entities.Company;

namespace DSEU.Application.Modules.Company.DepartmentMembers.Queries.GetAllDepartmentMembers
{
    public class GetAllDepartmentsMembersQueryHandler : IRequestHandler<GetAllDepartmentMembersQuery, IEnumerable<DepartmentMemberDto>>
    {
        private readonly IReadOnlyApplicationDbContext dbContext;

        public GetAllDepartmentsMembersQueryHandler(IReadOnlyApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<DepartmentMemberDto>> Handle(GetAllDepartmentMembersQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Query<DepartmentRecipientLinks>()
                                                  .Join(dbContext.Query<Employee>(), s => s.MemberId, d => d.Id, (s, d) => new DepartmentMemberDto
                                                  {
                                                      EmployeeId = s.MemberId,
                                                      DepartmentId = s.GroupId,
                                                      IsReadonly = d.DepartmentId == request.DepartmentId
                                                  })
                                                  .Where(p => p.DepartmentId == request.DepartmentId));
        }
    }
}
