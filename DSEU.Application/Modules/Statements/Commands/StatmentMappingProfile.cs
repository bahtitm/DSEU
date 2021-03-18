using AutoMapper;
using DSEU.Application.Modules.Statements.Commands.RegisterStatement;
using DSEU.Domain.Entities.RealEstateRights;
using DSEU.Domain.Entities.SubjectsOfRights;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace DSEU.Application.Modules.Statements.Commands
{
    public class StatmentMappingProfile : Profile
    {
        public StatmentMappingProfile()
        {
            CreateMap<RegisterStatementCommand, Statement>()
                .ForMember(r => r.AcceptedDocuments, s => s.MapFrom(item => item.AcceptedDocuments))
                .ForMember(r => r.Applicant, s => s.MapFrom(item => item.Applicant))
                .ForMember(r => r.DateTime, s => s.MapFrom(item => DateTime.Now))
                .ForMember(r => r.Decision, s => s.MapFrom(item => ""))
                .ForMember(r => r.Id, s => s.MapFrom(item => 0))
                .ForMember(r => r.Index, s => s.MapFrom(item => 0))
                //.ForMember(r => r.IssuedDocuments, s => s.MapFrom(item => { null }))
                .ForMember(r => r.Note, s => s.MapFrom(item => item.Note))
                .ForMember(r => r.Purpose, s => s.MapFrom(item => item.Purpose))
                .ForMember(r => r.RealEstate, s => s.MapFrom(item => item.RealEstate))
                //.ForMember(r => r.RealEstateRight, s => s.MapFrom(item => item.))
                ;
            CreateMap<ApplicantDto, Applicant>();


            
        }

    }
}
