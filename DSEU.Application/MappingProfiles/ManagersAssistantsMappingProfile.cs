using AutoMapper;
using DSEU.Application.Modules.Company.ManagersAssistants.Commands.CreateManagersAssistant;
using DSEU.Application.Modules.Company.ManagersAssistants.Commands.EditManagersAssistant;
using DSEU.Domain.Entities.Company;

namespace DSEU.Application.MappingProfiles
{
    public class ManagersAssistantsMappingProfile : Profile
    {
        public ManagersAssistantsMappingProfile()
        {
            CreateMap<CreateManagersAssistantCommand, ManagersAssistant>()
                .ForMember(p => p.ManagerId, p => p.MapFrom(p => p.Manager.Id))
                .ForMember(p => p.Manager, p => p.Ignore())
                .ForMember(p => p.AssistantId, p => p.MapFrom(p => p.Assistant.Id))
                .ForMember(p => p.Assistant, p => p.Ignore());

            CreateMap<EditManagersAssistantCommand, ManagersAssistant>()
                .ForMember(p => p.ManagerId, p => p.MapFrom(p => p.Manager.Id))
                .ForMember(p => p.Manager, p => p.Ignore())
                .ForMember(p => p.AssistantId, p => p.MapFrom(p => p.Assistant.Id))
                .ForMember(p => p.Assistant, p => p.Ignore());
        }
    }
}
