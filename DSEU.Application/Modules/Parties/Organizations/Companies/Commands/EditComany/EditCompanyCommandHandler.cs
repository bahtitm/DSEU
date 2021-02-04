using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Modules.Parties.Organizations.Companies.Models;

namespace DSEU.Application.Modules.Parties.Organizations.Companies.Commands.EditComany
{

    public class EditCompanyCommandHandler : IRequestHandler<EditCompanyCommand, CompanyDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public EditCompanyCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<CompanyDto> Handle(EditCompanyCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.FindByIdAsync<Domain.Entities.Parties.Company>(request.Id, cancellationToken);
            mapper.Map(request, entity);
            await dbContext.SaveChangesAsync();
            return mapper.Map<CompanyDto>(entity);
        }

    }
}
