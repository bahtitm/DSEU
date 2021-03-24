using Nest;

namespace DSEU.Infrastructure.ElasticSearch.Interfaces
{
    public interface IElasticSearchConnect
    {
        ElasticClient ConnectToElasticSearch();
    }
}