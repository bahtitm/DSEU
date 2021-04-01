using AutoMapper;
using DSEU.Application.Modules.Company.OurOrganization.JobTitles.Commands.CreateJobTitle;
using DSEU.Application.Modules.Company.OurOrganization.JobTitles.Commands.UpdateJobTitle;
using DSEU.Application.Modules.Company.OurOrganization.JobTitles.Dtos;
using DSEU.Domain.Entities.OurOrganization;

namespace DSEU.Application.Modules.Company.OurOrganization.JobTitles.MappingProfile
{
    public class JobTitleMappingProfile : Profile
    {
        public JobTitleMappingProfile()
        {
            CreateMap<CreateJobTitleCommand, JobTitle>();
            CreateMap<UpdateJobTitleCommand, JobTitle>();
            CreateMap<JobTitle, JobTitleDto>();
        }
    }
}
