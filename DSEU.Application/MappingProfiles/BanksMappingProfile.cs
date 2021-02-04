using AutoMapper;
using DSEU.Application.Modules.Parties.Organizations.Banks.Commands.CreateBank;
using DSEU.Application.Modules.Parties.Organizations.Banks.Commands.EditBank;
using DSEU.Domain.Entities.Parties;

namespace DSEU.Application.MappingProfiles
{
    public class BanksMappingProfile : Profile
    {
        public BanksMappingProfile()
        {
            CreateMap<CreateBankCommand, Bank>();
            CreateMap<EditBankCommand, Bank>();
        }
    }
}
