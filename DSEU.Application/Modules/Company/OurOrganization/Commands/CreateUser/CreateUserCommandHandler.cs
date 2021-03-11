using AutoMapper;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.OurOrganization;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Company.OurOrganization.Commands.CreateUser
{
    public class CreateUserCommandHandler : AsyncRequestHandler<CreateUserCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public CreateUserCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected override async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = mapper.Map<User>(request);
            await dbContext.AddAsync(user);
            await dbContext.SaveChangesAsync();
        }
    }
}
