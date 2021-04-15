using MediatR;

namespace DSEU.Application.Modules.SubjectsOfRights.Applicants.Commands.DeleteApplicant
{
    public record DeleteApplicantCommand(int id) : IRequest;
}
