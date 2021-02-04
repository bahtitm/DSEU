using MediatR;

namespace DSEU.Application.Modules.Commons.Countries.Commands.RemoveCountry
{
    public class RemoveCountryCommand : IRequest
    {
        public RemoveCountryCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
