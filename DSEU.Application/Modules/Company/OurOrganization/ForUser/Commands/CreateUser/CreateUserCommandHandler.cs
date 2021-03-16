using AutoMapper;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.OurOrganization;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Company.OurOrganization.ForUser.Commands.CreateUser
{
    public class CreateUserCommandHandler : AsyncRequestHandler<CreateUserCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IIdentityService identityService;

        public CreateUserCommandHandler(IApplicationDbContext dbContext, IMapper mapper, IIdentityService identityService)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.identityService = identityService;
        }

        protected override async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = mapper.Map<User>(request);
            var identytiuserId = await identityService.CreateUserAsync(user.Name, user.Email, "123456", cancellationToken: cancellationToken);
            user.UserId = identytiuserId;
            await dbContext.AddAsync(user);
            await dbContext.SaveChangesAsync();
        }
    }
}
