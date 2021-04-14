using AutoMapper;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.OurOrganization;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Company.OurOrganization.Departaments.Commands.UpdateDepartament
{
    public class UpdateDepartamentCommandHandler : AsyncRequestHandler<UpdateDepartamentCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public UpdateDepartamentCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected override async Task Handle(UpdateDepartamentCommand request, CancellationToken cancellationToken)
        {
            var departament = await dbContext.FindByIdAsync<Department>(request.Id);
            mapper.Map(request, departament);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
