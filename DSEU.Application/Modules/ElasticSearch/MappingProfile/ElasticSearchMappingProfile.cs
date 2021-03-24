using AutoMapper;
using DSEU.Application.Modules.ElasticSearch.Commands.CreateElasticSearch;
using DSEU.Application.Modules.ElasticSearch.Commands.DeleteElasticSearch;
using DSEU.Application.Modules.ElasticSearch.Entities;

namespace DSEU.Application.Modules.ElasticSearch.MappingProfile
{
    public class ElasticSearchMappingProfile : Profile
    {
        public ElasticSearchMappingProfile()
        {
            CreateMap<CreateElasticSearchCommand, ElasticStateRegister>();
            CreateMap<UpdateElasticSearchCommand, ElasticStateRegister>();
        }
    }
}
