﻿using MediatR;

namespace DSEU.Application.Modules.Company.OurOrganization.Commands.DeleteUser
{
    public class DeleteUserComand : IRequest
    {
        public DeleteUserComand(int Id)
        {
            this.Id = Id;
        }

        public int Id { get; }
    }
}
