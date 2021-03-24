using DSEU.Application.Common.Interfaces;
using DSEU.Application.Modules.ElasticSearch.Entities;
using DSEU.Application.Modules.ElasticSearch.Enum;
using DSEU.Infrastructure.ElasticSearch.Interfaces;
using Microsoft.Extensions.Options;
using Nest;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DSEU.Infrastructure.ElasticSearch
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

        public async Task AddSearchIndex<T>(T stateRegister) where T : class
        {

            var result = await client.IndexDocumentAsync(stateRegister);
            if (!result.IsValid)
            {
                throw new Exception();
            }
        }


        public async Task UpdateAsync<T>(int id, T obj) where T : class
        {
            var result = await client.UpdateAsync<T, object>(id, u => u
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
            if (searchField == SearchField.All)
            {
                var responseAll = await client.SearchAsync<StateRegisterSearchModel>(s => s
                         .From(elasticSearchOptions.ResponseIndexFrom)
                         .Size(elasticSearchOptions.ResponseCount)
                         .Query(q => q
                         .MultiMatch(mm => mm
                         .Query(query)
                         //.Analyzer("standard")
                         .Boost(elasticSearchOptions.BoostValue)
                         //.Slop(elasticSearchOptions.SlopCount)
                         .Fuzziness(Fuzziness.Auto)

                         )
                       )
                     );
                return responseAll.Documents;
            }
            else if (searchField == SearchField.FullName)
            {
                var responseFullName = await client.SearchAsync<StateRegisterSearchModel>(s => s
                         .From(elasticSearchOptions.ResponseIndexFrom)
                         .Size(elasticSearchOptions.ResponseCount)
                         .Query(q => q
                         .MultiMatch(mm => mm
                         .Fields(f => f.Fields(ff => ff.Applicant.FullName))
                         .Query(query)
                         //.Analyzer("standard")
                         .Boost(elasticSearchOptions.BoostValue)
                         //.Slop(elasticSearchOptions.SlopCount)
                         .Fuzziness(Fuzziness.Auto)

                         )
                       )
                     );
                return responseFullName.Documents;
            }
            else if (searchField == SearchField.Address)
            {
                var responseAddress = await client.SearchAsync<StateRegisterSearchModel>(s => s
                    .From(elasticSearchOptions.ResponseIndexFrom)
                    .Size(elasticSearchOptions.ResponseCount)
                    .Query(q => q
                    .MultiMatch(mm => mm
                    .Fields(f => f.Fields(bp => bp.Applicant.BirthPlace,
                                          dip => dip.Applicant.DocumentIssuePlace,
                                          rl => rl.Applicant.RecordLocation,
                                          ad => ad.RealEstate.Address))
                    .Query(query)
                    //.Analyzer("standard")
                    .Boost(elasticSearchOptions.BoostValue)
                    //.Slop(elasticSearchOptions.SlopCount)
                    .Fuzziness(Fuzziness.Auto)

                    )
                  )
                );
                return responseAddress.Documents;
            }
            return null;
        }


        public async Task<IEnumerable<StateRegisterSearchModel>> GetByRegionId(ElasticClient client, string query, List<int?> regionId, SearchField searchField)
        {
            var responseAll = await client.SearchAsync<StateRegisterSearchModel>(s => s
                      .From(elasticSearchOptions.ResponseIndexFrom)
                      .Size(elasticSearchOptions.ResponseCount)
                      .Query(q => q
                      .Bool(b => b
                      .Must(m =>m
                      .MultiMatch(mm => mm
                        .WithField(searchField)
                        .Fuzziness(Fuzziness.EditDistance(elasticSearchOptions.EditDistanceCount))
                      .Query(query)
                      //.Analyzer("standard")
                      .Boost(elasticSearchOptions.BoostValue)))
                      //.Slop(2)
                      .Filter(f => f
                      .Terms(t => t
                      .Field(f => f.RegionId)
                      .Terms(regionId)
                      )
                     )
                    )
                   )
                  );

            return responseAll.Documents;
            //if (searchField == SearchField.All)
            //{
            //    var responseAll = await client.SearchAsync<StateRegisterSearchModel>(s => s
            //          .From(elasticSearchOptions.ResponseIndexFrom)
            //          .Size(elasticSearchOptions.ResponseCount)
            //          .Query(q => q
            //          .Bool(b => b
            //          .Must(m => m
            //          .MultiMatch(mm => mm
            //          .Fuzziness(Fuzziness.EditDistance(elasticSearchOptions.EditDistanceCount))
            //          .Query(query)
            //          //.Analyzer("standard")
            //          .Boost(elasticSearchOptions.BoostValue)))
            //          //.Slop(2)
            //          .Filter(f => f
            //          .Terms(t => t
            //          .Field(f => f.RegionId)
            //          .Terms(regionId)
            //          )
            //         )
            //        )
            //       )
            //      );
            //    return responseAll.Documents;
            //}
            //else if (searchField == SearchField.FullName)
            //{
            //    var responseFullName = await client.SearchAsync<StateRegisterSearchModel>(s => s
            //          .From(elasticSearchOptions.ResponseIndexFrom)
            //          .Size(elasticSearchOptions.ResponseCount)
            //          .Query(q => q
            //          .Bool(b => b
            //          .Must(m => m
            //          .MultiMatch(mm => mm
            //          .Fields(f => f.Fields(ff => ff.Applicant.FullName))
            //          .Fuzziness(Fuzziness.EditDistance(elasticSearchOptions.EditDistanceCount))
            //          .Query(query)
            //          //.Analyzer("standard")
            //          .Boost(1.1)))
            //          //.Slop(2)
            //          .Filter(f => f
            //          .Terms(t => t
            //          .Field(f => f.RegionId)
            //          .Terms(regionId)
            //          )
            //         )
            //        )
            //       )
            //      );

            //    return responseFullName.Documents;
            //}
            //else if (searchField == SearchField.Address)
            //{
            //    var responseAddress = await client.SearchAsync<StateRegisterSearchModel>(s => s
            //              .From(elasticSearchOptions.ResponseIndexFrom)
            //              .Size(elasticSearchOptions.ResponseCount)
            //              .Query(q => q
            //              .Bool(b => b
            //              .Must(m => m
            //              .MultiMatch(mm => mm
            //              .Fields(f => f.Fields(bp => bp.Applicant.BirthPlace,
            //                                    dip => dip.Applicant.DocumentIssuePlace,
            //                                    rl => rl.Applicant.RecordLocation,
            //                                    ad => ad.RealEstate.Address))
            //              .Fuzziness(Fuzziness.EditDistance(2))
            //              .Query(query)
            //              //.Analyzer("standard")
            //              .Boost(elasticSearchOptions.BoostValue)))
            //              //.Slop(elasticSearchOptions.SlopCount)
            //              .Filter(f => f
            //              .Terms(t => t
            //              .Field(f => f.RegionId)
            //              .Terms(regionId)
            //              )
            //             )
            //            )
            //           )
            //          );

            //    return responseAddress.Documents;
            //}
            //return null;
        }


        public async Task<IEnumerable<StateRegisterSearchModel>> GetByDistrictId(ElasticClient client, string query, List<int?> regionId, List<int?> districtId, SearchField searchField)
        {
            if (searchField == SearchField.All)
            {
                var responseAll = await client.SearchAsync<StateRegisterSearchModel>(s => s
                      .From(elasticSearchOptions.ResponseIndexFrom)
                      .Size(elasticSearchOptions.ResponseCount)
                      .Query(q => q
                      .Bool(b => b
                      .Must(m => m
                      .MultiMatch(mm => mm
                      .Fuzziness(Fuzziness.EditDistance(elasticSearchOptions.EditDistanceCount))
                      .Query(query)
                      //.Analyzer("standard")
                      .Boost(elasticSearchOptions.BoostValue)))
                      //.Slop(elasticSearchOptions.SlopCount)
                      .Filter(f => f
                      .Terms(t => t
                      .Field(f => f.RegionId)
                      .Terms(regionId)), f => f
                        .Terms(t => t
                        .Field(f => f.DistrictId)
                        .Terms(districtId)
                      )
                     )
                    )
                   )
                  );
                return responseAll.Documents;
            }
            else if (searchField == SearchField.FullName)
            {
                var responseFullName = await client.SearchAsync<StateRegisterSearchModel>(s => s
                          .From(elasticSearchOptions.ResponseIndexFrom)
                          .Size(elasticSearchOptions.ResponseCount)
                          .Query(q => q
                          .Bool(b => b
                          .Must(m => m
                          .MultiMatch(mm => mm
                          .Fields(f => f.Fields(ff => ff.Applicant.FullName))
                          .Fuzziness(Fuzziness.EditDistance(elasticSearchOptions.EditDistanceCount))
                          .Query(query)
                          //.Analyzer("standard")
                          .Boost(elasticSearchOptions.BoostValue)))
                          //.Slop(elasticSearchOptions.SlopCount)
                          .Filter(f => f
                          .Terms(t => t
                          .Field(f => f.RegionId)
                          .Terms(regionId)), f => f
                            .Terms(t => t
                            .Field(f => f.DistrictId)
                            .Terms(districtId)
                          )
                         )
                        )
                       )
                      );

                return responseFullName.Documents;
            }
            if (searchField == SearchField.Address)
            {
                var responseAddress = await client.SearchAsync<StateRegisterSearchModel>(s => s
                          .From(elasticSearchOptions.ResponseIndexFrom)
                          .Size(elasticSearchOptions.ResponseCount)
                          .Query(q => q
                          .Bool(b => b
                          .Must(m => m
                          .MultiMatch(mm => mm
                          .Fields(f => f.Fields(bp => bp.Applicant.BirthPlace,
                                                dip => dip.Applicant.DocumentIssuePlace,
                                                rl => rl.Applicant.RecordLocation,
                                                ad => ad.RealEstate.Address))
                          .Fuzziness(Fuzziness.EditDistance(elasticSearchOptions.EditDistanceCount))
                          .Query(query)
                          //.Analyzer("standard")
                          .Boost(elasticSearchOptions.BoostValue)))
                          //.Slop(elasticSearchOptions.SlopCount)
                          .Filter(f => f
                          .Terms(t => t
                          .Field(f => f.RegionId)
                          .Terms(regionId)), f => f
                            .Terms(t => t
                            .Field(f => f.DistrictId)
                            .Terms(districtId)
                          )
                         )
                        )
                       )
                      );

                return responseAddress.Documents;
            }

            return null;
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


