using DSEU.Application.Modules.ElasticSearch.Entities;
using MediatR;
using System;

namespace DSEU.Application.Modules.ElasticSearch.Commands.DeleteElasticSearch
{
    public class UpdateElasticSearchCommand : IRequest
    {
        #region Commented
        //public int Id { get; set; }
        //public string ElectronicNumber { get; set; }
        //public string IndexNumber { get; set; }
        //public string ApplicationIndexNumber { get; set; }
        //public string RegisteredNumber { get; set; }
        //public string OrganizationalUnitNumber { get; set; }
        //public DateTime? EntryDate { get; set; }
        //public DateTime? RegistrationDate { get; set; }
        //public int? RegionId { get; set; }
        //public int? DistrictId { get; set; }
        //public string FullName { get; set; }
        //public string LastName { get; set; }
        //public string FirstName { get; set; }
        //public string MiddleName { get; set; }
        //public DateTime? BirthDate { get; set; }
        //public string BirthPlace { get; set; }
        //public string IdentityDocument { get; set; }
        //public string DocumentNumber { get; set; }
        //public DateTime? DocumentIssueDate { get; set; }
        //public string DocumentIssuePlace { get; set; }
        //public string Citizenship { get; set; }
        //public string RecordLocation { get; set; }
        //public string RightType { get; set; }
        //public string Part { get; set; }
        //public string StateRegistrar { get; set; }
        //public string CertificateNumber { get; set; }
        //public string BasesDocument { get; set; }
        //public string RealEstateType { get; set; }
        //public string Address { get; set; }
        //public string Description { get; set; }
        //public string CadastralNumber { get; set; }
        //public string InventoryNumber { get; set; }
        //public string CommonArea { get; set; }
        //public string LivingArea { get; set; }
        //public string Flat { get; set; }
        //public string RoomCount { get; set; }
        //public string InventoryCost { get; set; }
        //public string TransactionCost { get; set; }
        //public string TaxAmount { get; set; }
        //public string TaxNumber { get; set; }
        //public string MaintenanceAmount { get; set; }
        //public string MaintenanceNumber { get; set; }
        //public string Note { get; set; }
        #endregion

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
