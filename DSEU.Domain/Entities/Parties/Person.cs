using System;

namespace DSEU.Domain.Entities.Parties
{
    /// <summary>
    /// Персона
    /// </summary>
    public class Person : Counterparty
    {
        /// <summary>
        /// Фамилия
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; set; }
        /// <summary>
        /// Пол
        /// </summary>
        public Sex? Sex { get; set; }
        /// <summary>
        /// Фамилия и инициалы
        /// </summary>
        public string ShortName { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        public void RecomputePersonName()
        {
            Name = ComputeFullName();
            ShortName = ComputeShortName();
        }
        private string ComputeFullName()
        {
            return $"{LastName} {FirstName} {MiddleName}".Trim();
        }

        private string ComputeShortName()
        {
            var firstNameFirstSymbol = FirstName[0].ToString().ToUpper();
            string middleNameFirstSymbol = GetMiddleNameFirstSymbol(MiddleName);
            return $"{LastName} {firstNameFirstSymbol}{middleNameFirstSymbol}".Trim();
        }

        private string GetMiddleNameFirstSymbol(string middleName)
        {
            string middleNameFirstSymbol = string.Empty;
            if (!string.IsNullOrEmpty(middleName))
            {
                middleNameFirstSymbol = $".{middleName[0]}".ToUpper(); ;
            }

            return middleNameFirstSymbol;
        }
    }



}
