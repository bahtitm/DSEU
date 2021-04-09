using AutoMapper;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.OurOrganization;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Company.OurOrganization.Departaments.Commands.CreateDepartament
{
    public class CreateDepartamentCommandHandler : AsyncRequestHandler<CreateDepartamentCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public CreateDepartamentCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected override async Task Handle(CreateDepartamentCommand request, CancellationToken cancellationToken)
        {
            var departament = mapper.Map<Departament>(request);
            await dbContext.AddAsync(departament, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
