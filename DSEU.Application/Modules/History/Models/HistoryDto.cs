using System;
using AutoMapper;
using DSEU.Application.Common.Mapping;
using DSEU.Domain.Entities;
using DSEU.Domain.Entities.Content;

namespace DSEU.Application.Modules.History.Models
{
    public class HistoryDto : IMapFrom<DocumentHistory>
    {
        public DateTime HistoryDate { get; set; }
        public string User { get; set; }
        public int? UserId { get; set; }
        public string HostName { get; set; }
        public string UserAgent { get; set; }
        public int? Version { get; set; }
        public DocumentHistoryAction Action { get; set; }
        public string Comment { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DocumentHistory, HistoryDto>()
                .ForMember(p => p.User, d => d.MapFrom(p => p.User.Name));
        }
    }
}
