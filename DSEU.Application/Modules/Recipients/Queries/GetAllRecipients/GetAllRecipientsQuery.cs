using System.Collections.Generic;
using MediatR;
using DSEU.Application.Dtos;

namespace DSEU.Application.Modules.Recipients.Queries.GetAllRecipients
{
    public class GetAllRecipientsQuery : IRequest<IEnumerable<RecipientDto>>
    {

    }
}
