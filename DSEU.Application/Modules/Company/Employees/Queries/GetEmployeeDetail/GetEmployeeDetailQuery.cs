using MediatR;
using DSEU.Application.MappingProfiles;

namespace DSEU.Application.Modules.Company.Employees.Queries.GetEmployeeDetail
{
    public class GetEmployeeDetailQuery : IRequest<EmployeeDetailDto>
    {
        public GetEmployeeDetailQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
