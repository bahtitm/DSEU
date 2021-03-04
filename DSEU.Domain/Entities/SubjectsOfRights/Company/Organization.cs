using DSEU.Domain.Entities.SubjectsOfRights.Persons;

namespace DSEU.Domain.Entities.SubjectsOfRights.Company
{
    /// <summary>
    /// Организация
    /// </summary>
    public abstract class Organization : SubjectOfRight
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