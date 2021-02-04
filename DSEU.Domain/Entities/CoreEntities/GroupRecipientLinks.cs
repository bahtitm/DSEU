namespace DSEU.Domain.Entities.CoreEntities
{
    /// <summary>
    /// Состав участников
    /// </summary>
    public class GroupRecipientLinks
    {
        public int MemberId { get; set; }
        /// <summary>
        /// Участник
        /// </summary>
        public virtual Recipient Member { get; set; }
        public int GroupId { get; set; }
        /// <summary>
        /// Группа
        /// </summary>
        public Group Group { get; set; }

    }
}
