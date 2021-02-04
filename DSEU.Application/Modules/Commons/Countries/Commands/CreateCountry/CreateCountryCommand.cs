using MediatR;
using DSEU.Domain.Entities;

namespace DSEU.Application.Modules.Commons.Countries.Commands.CreateCountry
{
    public class CreateCountryCommand : IRequest
    {
        public string Name { get; set; }
        /// <summary>
        /// Состояние
        /// </summary>
        public Status Status { get; set; }
    }
}
