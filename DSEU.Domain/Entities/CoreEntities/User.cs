namespace DSEU.Domain.Entities.CoreEntities
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public abstract class User : Recipient
    {
        public int? LoginId { get; set; }
        /// <summary>
        /// Учетная запись
        /// </summary>
        public Login Login { get; set; }
        /// <summary>
        /// UserId
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// Фотография
        /// </summary>
        public byte[] PersonalPhoto { get; set; }
        /// <summary>
        /// Хеш фотографии
        /// </summary>
        public string PersonalPhotoHash { get; set; }
    }
}
