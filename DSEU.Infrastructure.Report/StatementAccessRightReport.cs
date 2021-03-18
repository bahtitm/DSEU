using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.RealEstateRights;

namespace DSEU.Infrastructure.Report
{
    public class StatementAccessRightReport : IReport<Statement>
    {
        public string TemplateName => "StatementAccessRight";
        public Format Format => Format.Docx;
        public Statement Data { get; init; }
        public StatementAccessRightReport(Statement statement)
        {
            Data = statement;
        }
    }
}
