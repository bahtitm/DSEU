using DSEU.Application.Common.Interfaces;
using System.Threading.Tasks;

namespace DSEU.Infrastructure.Report
{
    public class ReportGenerator : IReportGenerator
    {
        //public Task<(string contentType, byte[] data)> Generate<TData>(IReport<TData> report) where TData : class
        //{
        //    byte[] b = new byte[8];
        //    //var template = FastReport.LoadTemplate(report.TemplateName);
        //    //template.BindData(report.Data);
        //    //template.Export(report.Format.ToString());
        //    return Task<("",new byte[8])>;
        //}
        public Task<(string contentType, byte[] data)> Generate<TData>(IReport<TData> report) where TData : class
        {
            throw new System.NotImplementedException();
        }
    }
}
