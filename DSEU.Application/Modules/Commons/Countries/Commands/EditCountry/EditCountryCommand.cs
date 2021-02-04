using MediatR;
using DSEU.Domain.Entities;

namespace DSEU.Application.Modules.Commons.Countries.Commands.EditCountry
{
    public class EditCountryCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Status Status { get; set; }
    }
}
