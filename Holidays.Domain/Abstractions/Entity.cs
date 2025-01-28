using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holidays.Domain.Abstractions
{
    public abstract class Entity
    {
        public Guid Id { get; init; }

        private readonly List<IDomainEvent> _domainEvents = new();

        protected Entity(Guid id)
        {
            Id = id;
        }

        protected Entity() //Constructor vacio para que EF pueda generar la DB
        {
        }

        public IReadOnlyList<IDomainEvent> GetDomainEvents()
        {
            return _domainEvents.ToList();
        }
        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
        protected void RaiseDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
    }
}
