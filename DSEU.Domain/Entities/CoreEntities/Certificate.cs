using System;

namespace DSEU.Domain.Entities.CoreEntities
{
    /// <summary>
    /// Цифровой сертификат
    /// </summary>
    public class Certificate : DatabookEntry
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
        /// Владелец
        /// </summary>
        public User Owner { get; set; }
        /// <summary>
        /// Отпечаток
        /// </summary>
        public string Thumbprint { get; set; }
        /// <summary>
        /// Цифровой сертификат
        /// </summary>
        public byte[] X509Certificate { get; set; }
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
