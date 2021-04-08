using Nest;

namespace DSEU.Infrastructure.StateRegisterSearch
{
    public interface IElasticSearchConnect
    {
        ElasticClient ConnectToElasticSearch();
    }
}
