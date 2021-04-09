using AutoMapper;
using DSEU.Application.Modules.Company.OurOrganization.Branches.Commands.CreateBranch;
using DSEU.Application.Modules.Company.OurOrganization.Branches.Commands.UpdateBranch;
using DSEU.Application.Modules.Company.OurOrganization.Branches.Dtos;
using DSEU.Domain.Entities.OurOrganization;

namespace DSEU.Application.Modules.Company.OurOrganization.Branches.MappingProfile
{
    public class BranchMappingProfile : Profile
    {
        public BranchMappingProfile()
        {
            CreateMap<CreateBranchCommand, Branch>();
            CreateMap<UpdateBranchCommand, Branch>();

            CreateMap<Branch, BranchDto>();
        }
    }
}
