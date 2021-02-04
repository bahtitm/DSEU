using System.Collections.Generic;
using MediatR;
using DSEU.Application.Dtos.Company;

namespace DSEU.Application.Modules.Company.ManagersAssistants.Queries
{
    public class GetAllManagersAssistantsQuery : IRequest<IEnumerable<ManagersAssistantDto>>
    {
    }
}
