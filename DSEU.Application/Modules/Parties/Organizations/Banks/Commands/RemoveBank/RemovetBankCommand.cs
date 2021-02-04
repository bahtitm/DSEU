using MediatR;

namespace DSEU.Application.Modules.Parties.Organizations.Banks.Commands.RemoveBank
{
    public class RemoveBankCommand : IRequest
    {
        public int Id { get; set; }
    }
}
