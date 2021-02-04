using AutoMapper;
using DSEU.Application.Modules.Commons.Currencies.Commands.CreateCurrency;
using DSEU.Application.Modules.Commons.Currencies.Commands.EditCurrency;
using DSEU.Domain.Entities.Commons;

namespace DSEU.Application.MappingProfiles
{
    public class CurrencyMappingProfile : Profile
    {
        public CurrencyMappingProfile()
        {
            CreateMap<CreateCurrencyCommand, Currency>();
            CreateMap<EditCurrencyCommand, Currency>();
        }
    }
}
