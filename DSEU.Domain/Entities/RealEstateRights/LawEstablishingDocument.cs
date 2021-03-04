using System;

namespace DSEU.Domain.Entities.RealEstateRights
{
    /// <summary>
    /// Правоустанваливающий документ
    /// </summary>
    public class LawEstablishingDocument : BasisForChangeDocument
    {
        public DateTime? Date { get; set; }
        public string Number { get; set; }
        public string IssuedBy { get; set; }
    }
}
