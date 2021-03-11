using DSEU.Domain.Entities.SubjectsOfRights.Persons;

namespace DSEU.Domain.Entities.SubjectsOfRights.Company
{
    /// <summary>
    /// Организация
    /// </summary>
    public abstract class Organization : SubjectOfRight
    {
       
        /// <summary>
        /// представитель
        /// </summary>
        public Person Representative { get; set; }
        /// <summary>
        /// адресс оргнизации
        /// </summary>
       
        //Todo надо выяснить какие поля        
    }
}