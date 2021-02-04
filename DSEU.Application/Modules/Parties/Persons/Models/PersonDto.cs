using System;
using DSEU.Application.Common.Mapping;
using DSEU.Application.Modules.Parties.Shared.Models;
using DSEU.Domain.Entities.Parties;

namespace DSEU.Application.Modules.Parties.Persons.Models
{
    public class PersonDto : CounterPartBaseDto, IMapFrom<Person>
    {
        /// <summary>
        /// ���
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public string MiddleName { get; set; }
        /// <summary>
        /// ���� ��������
        /// </summary>
        public DateTime? DateOfBirth { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        public Sex Sex { get; set; }
    }
}
