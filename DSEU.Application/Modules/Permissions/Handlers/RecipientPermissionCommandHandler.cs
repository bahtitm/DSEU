using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Modules.Permissions.Commands;
using DSEU.Application.Services.Interfaces;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Application.Modules.Permissions.Handlers
{
    public class RecipientPermissionCommandHandler
        : IRequestHandler<DeleteRecipientPermissionCommand, Unit>,
          IRequestHandler<UpdateRecipientPermissionCommand, Unit>,
          IRequestHandler<CreateRecipientPermissionCommand, Unit>
    {
        private readonly IReadOnlyApplicationDbContext dbContext;
        private readonly IAccessRightsService accessRightsService;

        public RecipientPermissionCommandHandler(IAccessRightsService accessRightsService, IReadOnlyApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.accessRightsService = accessRightsService;
        }

        public async Task<Unit> Handle(DeleteRecipientPermissionCommand request, CancellationToken cancellationToken)
        {
            var accessRightEntry = await dbContext.Query<AccessRightEntry>().Include(p => p.Root).FirstOrDefaultAsync(p => p.Id == request.Id);
            await accessRightsService.RemovePermission(accessRightEntry.RecipientId, accessRightEntry.Root.EntityTypeGuid);
            return await Unit.Task;
        }

        public async Task<Unit> Handle(UpdateRecipientPermissionCommand request, CancellationToken cancellationToken)
        {
            await accessRightsService.UpdatePermission(request.RecipientId, request.EntityTypeGuid, request.Operation);

            return await Unit.Task;
        }

        public async Task<Unit> Handle(CreateRecipientPermissionCommand request, CancellationToken cancellationToken)
        {
            await accessRightsService.GrantPermission(request.RecipientId, request.EntityTypeGuid, request.Operation);

            return await Unit.Task;
        }
    }
}
