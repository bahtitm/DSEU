using System.Threading;
using System.Threading.Tasks;
using MediatR;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Application.Modules.Company.Employees.Commands.ChangePassword
{
    public class ChangePasswordCommandHandler : AsyncRequestHandler<ChangePasswordCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IIdentityService userManager;

        public ChangePasswordCommandHandler(IApplicationDbContext dbContext, IIdentityService userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }
        protected override async Task Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            await dbContext.InvokeTransactionAsync(async () =>
            {
                var user = await dbContext.FindByIdAsync<User>(request.Id , cancellationToken);
                await userManager.ChangeUserPassword(user.UserId, request.NewPassword, cancellationToken);
            }, cancellationToken);
        }
    }
}
