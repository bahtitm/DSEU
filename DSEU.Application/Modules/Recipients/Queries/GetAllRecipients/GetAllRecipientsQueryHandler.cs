using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Dtos;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Application.Modules.Recipients.Queries.GetAllRecipients
{
    public class GetAllRecipientsQueryHandler : IRequestHandler<GetAllRecipientsQuery, IEnumerable<RecipientDto>>
    {
        private readonly IReadOnlyApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetAllRecipientsQueryHandler(IReadOnlyApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<RecipientDto>> Handle(GetAllRecipientsQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext
                             .Query<Recipient>()
                             .Where(p => p.RecipientType != RecipientType.SystemUser)
                             .ProjectTo<RecipientDto>(mapper.ConfigurationProvider));
        }
    }
}
