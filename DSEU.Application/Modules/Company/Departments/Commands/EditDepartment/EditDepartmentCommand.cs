using MediatR;
using DSEU.Domain.Entities;

namespace DSEU.Application.Modules.Company.Departments.Commands.EditDepartment
{
    public class EditDepartmentCommand : IRequest
    {
        public int Id { get; set; }
        /// <summary>
        /// ������������
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// ���������� ��� ������������� � �����������
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// ������� ������������
        /// </summary>
        public string ShortName { get; set; }
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
        /// <summary>
        /// ������
        /// </summary>
        public Status Status { get; set; }
    }
}
