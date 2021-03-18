using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.OurOrganization;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Statements.Commands.RegisterStatement
{
    public class RegisterStatementCommand : IRequest
    {              
        /// <summary>
        /// Цель заявления
        /// </summary>
        public ApplicantDto Applicant { get; set; }
        /// <summary>
        /// Представитель
        /// </summary>
        public List<ApplicantDto> Representatives { get; set; }
        /// <summary>
        /// Цель заявления
        /// </summary>
        public string Purpose { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RealEstate { get; set; }
        /// <summary>
        /// Принятые документы от заявителя
        /// </summary>
        public List<string> AcceptedDocuments { get; set; }
        public int LocalityId { get; set; }
        public string Note { get; set; }
        public ICurrentUserService CurrentUserService { get; }
    }
}