using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Holidays.Domain.Users
{
    public sealed class Role
    {
        public static readonly Role Registered = new(1, "Registered");
        public int Id { get; init; }
        public string Name { get; init; }
        public ICollection<User> Users { get; init; } = new List<User>();
        public ICollection<Permission> Permissions { get; init; } = new List<Permission>();

        private Role(int id, string name)
        {
            Id = id; ;
            Name = name;
        }

        private Role()
        {
        }
    }
}
