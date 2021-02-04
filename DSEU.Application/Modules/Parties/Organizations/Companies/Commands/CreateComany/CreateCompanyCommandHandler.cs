using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Modules.Parties.Organizations.Companies.Models;

namespace DSEU.Application.Modules.Parties.Organizations.Companies.Commands.CreateComany
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, CompanyDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public CreateCompanyCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<CompanyDto> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Parties.Company entity = mapper.Map<Domain.Entities.Parties.Company>(request);
            await dbContext.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return mapper.Map<CompanyDto>(entity);
        }
    }
}
