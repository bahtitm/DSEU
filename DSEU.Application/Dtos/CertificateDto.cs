using System;
using DSEU.Application.Common.Mapping;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Application.Dtos
{
    /// <summary>
    /// Цифровой сертификат
    /// </summary>
    public class CertificateDto : DatabookEntryDto, IMapFrom<Certificate>
    {
        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Действующий
        /// </summary>
        public bool Enabled { get; set; }
        /// <summary>
        /// Конец срока действия
        /// </summary>
        public DateTime NotAfter { get; set; }
        /// <summary>
        /// Начало срока действия
        /// </summary>
        public DateTime NotBefore { get; set; }
        /// <summary>
        /// Кем выдан
        /// </summary>
        public string Issuer { get; set; }
        /// <summary>
        /// Кому выдан
        /// </summary>
        public string Subject { get; set; }
    }
}
