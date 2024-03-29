﻿using DSEU.Application.Common.Extensions;
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

        public DeleteUserComandHandler(IApplicationDbContext applicationDbContext)
        {
            dbContext = applicationDbContext;
        }

        protected override async Task Handle(DeleteUserComand request, CancellationToken cancellationToken)
        {
            var user = await dbContext.FindByIdAsync<User>(request.Id, cancellationToken);
            dbContext.Set<User>().Remove(user);
            await dbContext.SaveChangesAsync(cancellationToken);

        }
    }
}
