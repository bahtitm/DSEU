using System;
using DSEU.Application.Common.Mapping;
using DSEU.Application.Modules.Parties.Shared.Models;
using DSEU.Domain.Entities.Parties;

namespace DSEU.Application.Modules.Parties.Persons.Models
{
    public class PersonDto : CounterPartBaseDto, IMapFrom<Person>
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime? DateOfBirth { get; set; }
        /// <summary>
        /// Пол
        /// </summary>
        public Sex Sex { get; set; }
    }
}
