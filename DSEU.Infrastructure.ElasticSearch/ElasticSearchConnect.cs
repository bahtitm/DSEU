using DSEU.Infrastructure.ElasticSearch.Interfaces;
using Nest;
using System;

namespace DSEU.Infrastructure.ElasticSearch
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
