using System;
using MediatR;
using DSEU.Application.Modules.Parties.Persons.Models;
using DSEU.Application.Modules.Parties.Shared.Commands;
using DSEU.Domain.Entities.Parties;

namespace DSEU.Application.Modules.Parties.Persons.Commands.EditPerson
{
    public class EditPersonCommand : BaseUpdateCounterPartCommand, IRequest<PersonDto>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Account { get; set; }
        public int? BankId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Sex Sex { get; set; }
    }
}
