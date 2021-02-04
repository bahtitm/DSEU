namespace DSEU.Application.Dtos.Company
{
    public class EmployeeDto : UserDto
    {
        /// <summary>
        /// Рабочий телефон
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Эл. почта
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Примечание
        /// </summary>
        public string Note { get; set; }
        public string JobTitle { get; set; }
        public int BusinessUnitId { get; set; }
        public string UserName { get; set; }
        /// <summary>
        /// Подразделение
        /// </summary>
        public int? DepartmentId { get; set; }
        /// <summary>
        /// Должность
        /// </summary>
        public int? JobTitleId { get; set; }
    }
}
