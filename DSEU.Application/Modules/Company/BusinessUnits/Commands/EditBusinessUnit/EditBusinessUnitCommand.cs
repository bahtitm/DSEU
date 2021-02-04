using MediatR;
using DSEU.Domain.Entities;

namespace DSEU.Application.Modules.Company.BusinessUnits.Commands.EditBusinessUnit
{
    public class EditBusinessUnitCommand : IRequest
    {
        public int Id { get; set; }
        /// <summary>
        /// ������������
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        public string TIN { get; set; }
        /// <summary>
        /// �� ����������� ������
        /// </summary>
        public int? LocalityId { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public string Phones { get; set; }
        /// <summary>
        /// ����. ������������
        /// </summary>
        public string LegalName { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        public int RegionId { get; set; }
        /// <summary>
        /// ����������� �����
        /// </summary>
        public string LegalAddress { get; set; }
        /// <summary>
        /// �������� �����
        /// </summary>
        public string PostalAddress { get; set; }
        /// <summary>
        /// ����������
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// �� ������������ (���������)
        /// </summary>
        public int? CEO { get; set; }
        /// <summary>
        /// ��. �����
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public string Homepage { get; set; }
        /// <summary>
        /// ����� �����
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// �� �����
        /// </summary>
        public int? BankId { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// �� �������� ���
        /// </summary>
        public int? HeadCompanyId { get; set; }
        /// <summary>
        /// ���������
        /// </summary>
        public Status Status { get; set; }

    }
}
