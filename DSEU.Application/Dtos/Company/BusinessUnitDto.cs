using DSEU.Application.Common.Mapping;
using DSEU.Domain.Entities.Company;

namespace DSEU.Application.Dtos.Company
{
    public class BusinessUnitDto : RecipientBaseDto, IMapFrom<BusinessUnit>
    {
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
        public int? RegionId { get; set; }
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
        public int? HeadCompanyId { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        public string Code { get; set; }
    }
}
