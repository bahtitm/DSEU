using MediatR;

namespace DSEU.Application.Modules.Commons.Currencies.Commands.RemoveCurrency
{
    public class RemoveCurrencyCommand : IRequest
    {
        public RemoveCurrencyCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
