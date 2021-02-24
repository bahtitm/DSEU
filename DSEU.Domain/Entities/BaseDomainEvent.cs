using MediatR;
using System;

namespace DSEU.Domain.Entities
{
    public abstract class BaseDomainEvent : INotification
    {
        public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
    }
}