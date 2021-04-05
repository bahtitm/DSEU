namespace DSEU.Application.Common.Interfaces
{
    public interface IReport<TData> where TData : class
    {
        string TemplateName { get; }
        Format Format { get; }
        TData Data { get; }
    }
    public enum Format
    {
        Pdf,
        Docx
    }
}
