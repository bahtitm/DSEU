using DSEU.StateRegisterSearch.Interfaces;
using DSEU.StateRegisterSearch.Interfaces.Dtos;
using DSEU.StateRegisterSearch.Interfaces.Enums;
using Microsoft.Extensions.Options;
using Nest;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DSEU.Infrastructure.StateRegisterSearch
{
    public class StateRegisterSearchService : IStateRegisterSearchService
    {
        private readonly ElasticClient client;
        private readonly ElasticSearchOptions elasticSearchOptions;
        public StateRegisterSearchService(IElasticSearchConnect elasticSearchConnect, IOptions<ElasticSearchOptions> options)
        {
            client = elasticSearchConnect.ConnectToElasticSearch();
            elasticSearchOptions = options.Value;
        }

        public async Task AddSearchIndex(StateRegisterSearchModel stateRegister)
        {

            var result = await client.IndexDocumentAsync(stateRegister);
            if (!result.IsValid)
            {
                throw new Exception();
            }
        }

        public async Task UpdateAsync(int id, StateRegisterSearchModel obj)
        {
            var result = await client.UpdateAsync<StateRegisterSearchModel, object>(id, u => u
                                                    .Doc(obj)
                                                    .RetryOnConflict(elasticSearchOptions.RetryOnConflict)
                                                    /*.Refresh(Refresh.True)*/);

            if (!result.IsValid)
            {
                throw new Exception();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var result = await client.DeleteAsync<StateRegisterSearchModel>(id);

            if (!result.IsValid)
            {
                throw new Exception();
            }
        }


        public async Task<IEnumerable<StateRegisterSearchModel>> GetAsync(string query, List<int?> regionId, List<int?> districtId, SearchField searchField)
        {

            if (string.IsNullOrEmpty(query) || string.IsNullOrWhiteSpace(query))
            {
                return null;
            }

            if (regionId.Count == 0)
            {
                return await GetAll(client, query, searchField);
            }
            else if (districtId.Count == 0)
            {
                return await GetByRegionId(client, query, regionId, searchField);
            }
            else
            {
                return await GetByDistrictId(client, query, regionId, districtId, searchField);
            }
        }


        public async Task<IEnumerable<StateRegisterSearchModel>> GetAll(ElasticClient client, string query, SearchField searchField)
        {
                var response = await client.SearchAsync<StateRegisterSearchModel>(s => s
                         .From(0)
                         .Size(10)
                         .Query(q => q
                         .MultiMatch(mm => mm
                         .WithField(searchField)
                         .Query(query)
                         .Boost(1.1)
                         .Slop(2)
                         .Fuzziness(Fuzziness.Auto)))
                     );
                return response.Documents;
        }


        public async Task<IEnumerable<StateRegisterSearchModel>> GetByRegionId(ElasticClient client, string query, List<int?> regionId, SearchField searchField)
        {
            var responseAll = await client.SearchAsync<StateRegisterSearchModel>(s => s
                      .From(0)
                      .Size(10)
                      .Query(q => q
                      .Bool(b => b
                      .Must(m => m
                      .MultiMatch(mm => mm
                        .WithField(searchField)
                        .Fuzziness(Fuzziness.EditDistance(2))
                      .Query(query)
                      .Boost(1.1)))
                      //.Slop(2)
                      .Filter(f => f
                      .Terms(t => t
                      .Field(f => f.RegionId)
                      .Terms(regionId)))))
                  );
            return responseAll.Documents;
        }


        public async Task<IEnumerable<StateRegisterSearchModel>> GetByDistrictId(ElasticClient client, string query, List<int?> regionId, List<int?> districtId, SearchField searchField)
        {
            var response = await client.SearchAsync<StateRegisterSearchModel>(s => s
                         .From(0)
                         .Size(10)
                         .Query(q => q
                         .Bool(b => b
                         .Must(m => m
                         .MultiMatch(mm => mm
                         .WithField(searchField)
                         .Fuzziness(Fuzziness.EditDistance(2))
                         .Query(query)
                         .Boost(1.1)))
                         //.Slop(elasticSearchOptions.SlopCount)
                         .Filter(f => f
                         .Terms(t => t
                         .Field(f => f.RegionId)
                         .Terms(regionId)), f => f
                           .Terms(t => t
                           .Field(f => f.DistrictId)
                           .Terms(districtId)))))
                     );
            return response.Documents;
        }
    }

    public static class MultimatchFieldDescriptorExtensions
    {
        public static MultiMatchQueryDescriptor<StateRegisterSearchModel> WithField(this MultiMatchQueryDescriptor<StateRegisterSearchModel> descriptor, SearchField field)
        {
            if (field == SearchField.FullName)
            {
                descriptor.Fields(desc => desc.Fields(p => p.Applicant.FullName));
            }
            if (field == SearchField.Address)
            {
                descriptor.Fields(desc => desc.Fields(bp => bp.Applicant.BirthPlace,
                                                      dip => dip.Applicant.DocumentIssuePlace,
                                                      rl => rl.Applicant.RecordLocation,
                                                      ad => ad.RealEstate.Address));
            }
            return descriptor;
        }
    }
}
