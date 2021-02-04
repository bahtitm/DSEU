using AutoMapper;
using DSEU.Application.Modules.Parties.Persons.Commands.CreatePerson;
using DSEU.Application.Modules.Parties.Persons.Commands.EditPerson;
using DSEU.Domain.Entities.Parties;

namespace DSEU.Application.MappingProfiles
{
    public class PersonsMappingProfile : Profile
    {
        public PersonsMappingProfile()
        {
            CreateMap<EditPersonCommand, Person>();

            CreateMap<CreatePersonCommand, Person>();
        }
    }
}
