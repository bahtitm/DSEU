using AutoMapper;
using DSEU.Application.Common.Mapping;
using DSEU.Application.Dtos;
using DSEU.Domain.Entities.Company;

namespace DSEU.Application.MappingProfiles
{
    public class EmployeeDetailDto : UserDto, IMapFrom<Employee>
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
        public int BusinessUnitId { get; set; }
        /// <summary>
        /// Подразделение
        /// </summary>
        public int? DepartmentId { get; set; }
        /// <summary>
        /// Должность
        /// </summary>
        public int? JobTitleId { get; set; }
        public string UserName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, EmployeeDetailDto>()
                .ForMember(dp => dp.UserName, sp => sp.MapFrom(sp => sp.Login.LoginName))
                .ForMember(dp => dp.BusinessUnitId, sp => sp.MapFrom(sp => sp.Department.BusinessUnitId));
        }
    }
}
