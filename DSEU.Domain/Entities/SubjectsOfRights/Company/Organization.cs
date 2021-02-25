using DSEU.Domain.Entities.Persons;
using DSEU.Domain.Entities.SubjectsOfRights;

namespace DSEU.Domain.Entities.Company
{
    /// <summary>
    /// Организация
    /// </summary>
    public abstract class Organization : SubjectsOfRight
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