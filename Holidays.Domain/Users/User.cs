using Holidays.Domain.Abstractions;
using Holidays.Domain.Users.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holidays.Domain.Users
{
    public sealed class User : Entity
    {
        private readonly List<Role> _roles = new();
        public FirstName FirstName { get; private set; }
        public LastName LastName { get; private set; }
        public Email Email { get; private set; }       
        public IReadOnlyCollection<Role> Roles => _roles.ToList();

        private User(Guid id, FirstName firstName, LastName lastname, Email email) : base(id)
        {
            FirstName = firstName;
            LastName = lastname;
            Email = email;
        }
        private User() //Constructor vacio para que EF pueda generar la DB
        {
        }

        public static User Create(FirstName firstName, LastName lastName, Email email)
        {
            var user = new User(Guid.NewGuid(), firstName, lastName, email);

            user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id));

            user._roles.Add(Role.Registered);

            return user;
        }
    }
}
