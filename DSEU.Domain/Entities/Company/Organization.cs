using DSEU.Domain.Entities.Persons;

namespace DSEU.Domain.Entities.Company
{
    /// <summary>
    /// Организация
    /// </summary>
    public abstract class Organization : BaseEntity
    {
        public string Name { get; set; }
        /// <summary>
        /// представитель
        /// </summary>
        public Person Representative { get; set; }
        /// <summary>
        /// адресс оргнизации
        /// </summary>
        public string Address { get; set; }
        //Todo надо выяснить какие поля        
    }
}