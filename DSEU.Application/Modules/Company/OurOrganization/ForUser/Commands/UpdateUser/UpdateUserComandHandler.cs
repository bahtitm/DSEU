using AutoMapper;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using DSEU.Domain.Entities.OurOrganization;

namespace DSEU.Application.Modules.Company.OurOrganization.ForUser.Commands.UpdateUser
{
    public class UpdateUserComandHandler : AsyncRequestHandler<UpdateUserComand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public UpdateUserComandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;

        }
        protected override async Task Handle(UpdateUserComand request, CancellationToken cancellationToken)
        {
            var user = await dbContext.FindByIdAsync<User>(request.Id, cancellationToken);

            mapper.Map(request, user);

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
