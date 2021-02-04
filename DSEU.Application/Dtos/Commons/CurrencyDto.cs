using DSEU.Application.Common.Mapping;
using DSEU.Domain.Entities.Commons;

namespace DSEU.Application.Dtos.Commons
{
    public class CurrencyDto : DatabookEntryDto, IMapFrom<Currency>
    {
        /// <summary>
        /// ������������
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// ��������� ���
        /// </summary>
        public string AlphaCode { get; set; }
        /// <summary>
        /// ����. ������������
        /// </summary>
        public string ShortName { get; set; }
        /// <summary>
        /// ������� �����
        /// </summary>
        public string FractionName { get; set; }
        /// <summary>
        /// ������ �� ���������
        /// </summary>
        public bool IsDefault { get; set; }
        /// <summary>
        /// �������� ���
        /// </summary>
        public string NumericCode { get; set; }
    }
}
