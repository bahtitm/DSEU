namespace DSEU.Application.Dtos
{
    public class UserDto : RecipientBaseDto
    {
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
