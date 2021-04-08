using Nest;
using System;

namespace DSEU.Infrastructure.StateRegisterSearch
{
    public class ElasticSearchConnect : IElasticSearchConnect
    {
        public ElasticClient ConnectToElasticSearch()
        {
            var settings = new ConnectionSettings(new Uri("http://localhost:9200")).DefaultIndex("state_register");
            return new ElasticClient(settings);
        }
    }
}
