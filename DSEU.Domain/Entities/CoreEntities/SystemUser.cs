namespace DSEU.Domain.Entities.CoreEntities
{
    /// <summary>
    /// Системный пользователь
    /// </summary>
    public class SystemUser : User
    {
        public SystemUser()
        {
            IsSystem = true;
        }
    }
}
