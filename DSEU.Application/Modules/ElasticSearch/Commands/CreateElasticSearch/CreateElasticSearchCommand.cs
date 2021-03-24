using DSEU.Application.Modules.ElasticSearch.Entities;
using MediatR;
using System;

namespace DSEU.Application.Modules.ElasticSearch.Commands.CreateElasticSearch
{
    public class CreateElasticSearchCommand : IRequest
    {
        public int Id { get; set; }
        public ElasticStateRegisterNumber StateRegisterNumber { get; set; }
        public DateTime? EntryDate { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public int? RegionId { get; set; }
        public int? DistrictId { get; set; }
        public ElasticApplicant Applicant { get; set; }
        public ElasticRealEstateRight RealEstateRight { get; set; }
        public ElasticRealEstate RealEstate { get; set; }
        public ElasticTax Tax { get; set; }
        public string Note { get; set; }
        public string Gbti { get; set; }
    }
}
