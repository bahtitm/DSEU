using System.Collections.Generic;
using MediatR;
using DSEU.Application.Modules.History.Models;
using DSEU.Domain.Entities;

namespace DSEU.Application.Modules.History.Queries.GetHistoryByEntity
{
    public class GetHistoryByEntityQuery : IRequest<IEnumerable<HistoryDto>>
    {
        public GetHistoryByEntityQuery(EntityTypeGuid entityTypeGuid, int id)
        {
            EntityTypeGuid = entityTypeGuid;
            Id = id;
        }

        public EntityTypeGuid EntityTypeGuid { get; }
        public int Id { get; }
    }
}
