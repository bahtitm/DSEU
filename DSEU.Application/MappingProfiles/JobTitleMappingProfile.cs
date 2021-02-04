using AutoMapper;
using DSEU.Application.Modules.Company.JobTitles.Commands.CreateJobTitle;
using DSEU.Application.Modules.Company.JobTitles.Commands.EditJobTitle;
using DSEU.Domain.Entities.Company;

namespace DSEU.Application.MappingProfiles
{
    public class JobTitleMappingProfile : Profile
    {
        public JobTitleMappingProfile()
        {
            CreateMap<CreateJobTitleCommand, JobTitle>();
            CreateMap<EditJobTitleCommand, JobTitle>();
        }
    }
}
