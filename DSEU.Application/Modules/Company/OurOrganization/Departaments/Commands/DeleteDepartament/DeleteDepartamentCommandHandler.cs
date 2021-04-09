using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.OurOrganization;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Company.OurOrganization.Departaments.Commands.DeleteDepartament
{
    public class DeleteDepartamentCommandHandler : AsyncRequestHandler<DeleteDepartamentCommand>
    {
        private readonly IApplicationDbContext dbContext;
        public DeleteDepartamentCommandHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        protected override async Task Handle(DeleteDepartamentCommand request, CancellationToken cancellationToken)
        {
            var departament = await dbContext.FindByIdAsync<Departament>(request.id);
            dbContext.Set<Departament>().Remove(departament);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
