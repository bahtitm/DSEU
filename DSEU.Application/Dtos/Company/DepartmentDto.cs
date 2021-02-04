using DSEU.Application.Common.Mapping;
using DSEU.Domain.Entities.Company;

namespace DSEU.Application.Dtos.Company
{
    public class DepartmentDto : RecipientBaseDto, IMapFrom<Department>
    {
        /// <summary>
        /// ������� ������������
        /// </summary>
        public string ShortName { get; set; }
        /// <summary>
        /// ���������� ��� ������������� � �����������
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// ����������
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// Id ��������� �������������
        /// </summary>
        public int? HeadOfficeId { get; set; }
        /// <summary>
        /// Id �����������
        /// </summary>
        public int BusinessUnitId { get; set; }
        /// <summary>
        /// Id ������������ �������������
        /// </summary>
        public int? ManagerId { get; set; }
    }
}
