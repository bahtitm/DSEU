using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.OurOrganization;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Company.OurOrganization.ForUser.Commands.DeleteUser
{
    public class DeleteUserComandHandler : AsyncRequestHandler<DeleteUserComand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IIdentityService identityService;

        public DeleteUserComandHandler(IApplicationDbContext applicationDbContext, IIdentityService identityService)
        {
            dbContext = applicationDbContext;
            this.identityService = identityService;
        }

        protected override async Task Handle(DeleteUserComand request, CancellationToken cancellationToken)
        {
            await dbContext.InvokeTransactionAsync(async () =>
            {
                var user = await dbContext.FindByIdAsync<User>(request.Id, cancellationToken);
                
                await identityService.RemoveFromRoleAsync(user.UserId);
                
                dbContext.Set<User>().Remove(user);
                await dbContext.SaveChangesAsync(cancellationToken);
            }, cancellationToken);
        }
    }
}
