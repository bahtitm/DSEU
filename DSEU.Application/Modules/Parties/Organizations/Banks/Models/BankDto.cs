using DSEU.Application.Common.Mapping;
using DSEU.Application.Modules.Parties.Shared.Models;
using DSEU.Domain.Entities.Parties;

namespace DSEU.Application.Modules.Parties.Organizations.Banks.Models
{
    public class BankDto : CompanyBaseDto, IMapFrom<Bank>
    {
        /// <summary>
        /// Банковский уникальный идентификационный код
        /// </summary>
        public string BIC { get; set; }
        /// <summary>
        /// Номер корр. счета
        /// </summary>
        public string CorrespondentAccount { get; set; }
    }
}
