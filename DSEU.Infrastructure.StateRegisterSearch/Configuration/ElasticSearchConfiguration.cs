using DSEU.StateRegisterSearch.Interfaces.Dtos;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSEU.Infrastructure.StateRegisterSearch.Configuration
{
    public class ElasticSearchConfiguration
    {
        private readonly IElasticSearchConnect elasticSearchService;

        public ElasticSearchConfiguration(IElasticSearchConnect elasticSearchService)
        {
            this.elasticSearchService = elasticSearchService;
        }

        public async Task<ElasticClient> CreateElasticSearchIndex()
        {
            var client = elasticSearchService.ConnectToElasticSearch();

            await client.Indices.CreateAsync("state_register", c => c
                .Settings(s => s
                   .Analysis(a => a
                        .Analyzers(analyzer => analyzer
                            .Custom("substring_analyzer", analyzerDescriptor => analyzerDescriptor
                                .Tokenizer("standard")
                                .Filters("lowercase", "substring", "myLatinTransform")
                            ))
                            .TokenFilters(tf => tf
                                .EdgeNGram("substring", filterDescriptor => filterDescriptor
                                    .MinGram(2)
                                    .MaxGram(15)
                                    )
                                .IcuTransform("myLatinTransform", filterTransform => filterTransform
                                    .Id("Any-Latin; NFD; [:Nonspacing Mark:] Remove; NFC")
                                    )
                                )
                            )
                    )
                    .Map<StateRegisterSearchModel>(m => m
                        .AutoMap()
                        .Properties(ps => ps
                            .Object<StateRegisterNumber>(n => n
                                .Name(n => n.StateRegisterNumber)
                                    .AutoMap()
                                )
                            )
                        .Properties(ps => ps
                            .Object<StateRegisterApplicant>(n => n
                                .Name(n => n.Applicant)
                                .AutoMap()
                                    .Properties(ps => ps
                                        .Text(t => t
                                            .Name(n => n.FullName)
                                            .Analyzer("substring_analyzer")
                                            .SearchAnalyzer("substring_analyzer")
                                           )
                                        .Text(t => t
                                            .Name(n => n.FirstName)
                                            .Analyzer("substring_analyzer")
                                            .SearchAnalyzer("substring_analyzer")
                                           )
                                        .Text(t => t
                                            .Name(n => n.LastName)
                                             .Analyzer("substring_analyzer")
                                            .SearchAnalyzer("substring_analyzer")
                                        )
                                        .Text(t => t
                                            .Name(n => n.MiddleName)
                                             .Analyzer("substring_analyzer")
                                            .SearchAnalyzer("substring_analyzer")
                                        )
                                         .Text(t => t
                                            .Name(n => n.BirthPlace)
                                             .Analyzer("substring_analyzer")
                                            .SearchAnalyzer("substring_analyzer")
                                        )
                                          .Text(t => t
                                            .Name(n => n.DocumentNumber)
                                             .Analyzer("substring_analyzer")
                                            .SearchAnalyzer("substring_analyzer")
                                        )
                                           .Text(t => t
                                            .Name(n => n.DocumentIssuePlace)
                                             .Analyzer("substring_analyzer")
                                            .SearchAnalyzer("substring_analyzer")
                                        )
                                            .Text(t => t
                                            .Name(n => n.RecordLocation)
                                             .Analyzer("substring_analyzer")
                                            .SearchAnalyzer("substring_analyzer")
                                        )
                                     )
                                 )
                            )
                        .Properties(ps => ps
                            .Object<StateRegisterRealEstateRight>(n => n
                                .Name(n => n.RealEstateRight)
                                .AutoMap()
                                )
                            )
                        .Properties(ps => ps
                            .Object<StateRegisterRealEstate>(n => n
                                .Name(n => n.RealEstate)
                                .AutoMap()
                                    .Properties(ps => ps
                                        .Text(t => t
                                            .Name(n => n.Address)
                                            .Analyzer("substring_analyzer")
                                            .SearchAnalyzer("substring_analyzer")
                                           )
                                        )
                                    )
                            )
                        .Properties(ps => ps
                            .Object<StateRegisterTax>(n => n
                                .Name(n => n.Tax)
                                .AutoMap()
                                    )
                            )
                        )

             );

            return client;
        }
    }
}
