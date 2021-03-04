using DSEU.Domain.Entities.RealEstates;
using System;
using System.Collections.Generic;

namespace DSEU.Domain.Entities.RealEstateRights.Cases
{
    /// <summary>
    /// Дело недвижимости (в самой орг. называется Регестроционная дело папка где хрониться вся история, документы)
    /// </summary>
    public class RealEstateCase:BaseEntity
    {
        public ICollection<Number> Numbers { get; set; }
        /// <summary>
        /// недвижимость
        /// </summary>
        public RealEstate RealEstate { get; set; }
        /// <summary>
        /// Дата Открытие дело
        /// </summary>
        public DateTime? OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }
        /// <summary>
        /// Опись
        /// </summary>
        public Inventory Inventory { get; set; }

    }
    /// <summary>
    /// опись хранит опись документов в RealEstateCase
    /// </summary>
    public class Inventory
    {
        public string Number { get; set; }
        public string NameDokument { get; set; }
        /// <summary>
        /// количество страниц документа включенного в дело
        /// </summary>
        public int PageCount { get; set; }
        /// <summary>
        /// дата включение в дело
        /// </summary>
        public DateTime CaseEntriDate { get; set; }
    }

}
