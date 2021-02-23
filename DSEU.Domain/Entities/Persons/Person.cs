namespace DSEU.Domain.Entities.Persons
{
    /// <summary>
    /// Личность
    /// </summary>
    public class Person : BaseEntity
    {
        /// <summary>
        /// Имя 
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public Passport Passport { get; set; }


        public string Registration { get; set; }
        public string Citizenship { get; set; }
        public PersonStatus PersonStatus { get; set; }

    }
}
