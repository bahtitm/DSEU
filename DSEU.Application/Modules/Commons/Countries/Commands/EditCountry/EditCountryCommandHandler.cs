using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.Commons;

namespace DSEU.Application.Modules.Commons.Countries.Commands.EditCountry
{
    public class EditCountryCommandHandler : AsyncRequestHandler<EditCountryCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public EditCountryCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected override async Task Handle(EditCountryCommand request, CancellationToken cancellationToken)
        {
            var country = await dbContext.FindByIdAsync<Country>(request.Id, cancellationToken);

            mapper.Map(request, country);

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
