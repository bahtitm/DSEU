using DSEU.Application.Modules.Statements.Commands;
using MediatR;

namespace DSEU.Application.Modules.SubjectsOfRights.Applicants.Queries.GetApplicantDetail
{
    public class GetApplicantDetailQuery : IRequest<ApplicantDto>
    {
        public int Id { get; set; }
        public GetApplicantDetailQuery(int id)
        {
            Id = id;
        }
    }
}
