using AutoMapper;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.RealEstateRights;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Statements.Commands.RegisterStatement
{
    public class RegisterStatementCommandHandler : AsyncRequestHandler<RegisterStatementCommand>
    {

        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public RegisterStatementCommandHandler(IApplicationDbContext dbContext,IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected override async Task Handle(RegisterStatementCommand request, CancellationToken cancellationToken)
        {
            var statement = mapper.Map<RegisterStatementCommand,Statement>(request);
            
            //Statement statement = new Statement
            //{
            //    //User = await currentUserService.GetUser(),
            //    Purpose = request.Purpose,
            //    DateTime = SystemTime.Now(),
            //    // Applicant = mapper.Map<Applicant>(request.Applicant),
            //    //Representatives = mapper.Map<List<Applicant>>(request.Representatives),
            //    AcceptedDocuments = request.AcceptedDocuments,
            //    // Index = await statementNumberProcessor.GenerateIndex(request.LocalityId),
            //    Note = request.Note
            //};
            await dbContext.AddAsync(statement);
            await dbContext.SaveChangesAsync();

            //byte[] file = await GenerateStatementTemplate(statement);

            //return new StatementDto(statement.Number, file);
        }

        //private async Task<byte[]> GenerateStatementTemplate(Statement statement)
        //{
        //    //TODO: Сгенерировать заявление Görnüş 34
        //    //var report = await reportGenerator.Generate(new StatementAccessRightReport(statement));
        //    //return report.data;
        //}
    }
}
