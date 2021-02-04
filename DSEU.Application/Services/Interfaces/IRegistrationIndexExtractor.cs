namespace DSEU.Application.Services.Interfaces
{
    public interface IRegistrationIndexExtractor
    {
        int ExtractIndexByPattern(string registrationNumber, string pattern);
    }
}
