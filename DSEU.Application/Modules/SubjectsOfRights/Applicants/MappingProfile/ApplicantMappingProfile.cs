using AutoMapper;
using DSEU.Application.Modules.Statements.Commands;
using DSEU.Application.Modules.SubjectsOfRights.Applicants.Commands.CreateApplicant;
using DSEU.Application.Modules.SubjectsOfRights.Applicants.Commands.UpdateApplicant;
using DSEU.Domain.Entities.SubjectsOfRights;

namespace DSEU.Application.Modules.SubjectsOfRights.Applicants.MappingProfile
{
    public class ApplicantMappingProfile : Profile
    {
        public ApplicantMappingProfile()
        {
            CreateMap<CreateApplicantCommand, Applicant>();
            CreateMap<UpdateApplicantCommand, Applicant>();

            CreateMap<Applicant, ApplicantDto>();
        }
    }
}
