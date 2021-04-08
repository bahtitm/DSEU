using System;

namespace DSEU.StateRegisterSearch.Interfaces.Dtos
{
    public class StateRegisterSearchModel
    {
        public int Id { get; set; }
        public StateRegisterNumber StateRegisterNumber { get; set; }
        public DateTime? EntryDate { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public int? RegionId { get; set; }
        public int? DistrictId { get; set; }
        public StateRegisterApplicant Applicant { get; set; }
        public StateRegisterRealEstateRight RealEstateRight { get; set; }
        public StateRegisterRealEstate RealEstate { get; set; }
        public StateRegisterTax Tax { get; set; }
        public string Note { get; set; }
        public string Gbti { get; set; }
    }
}
