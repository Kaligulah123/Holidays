using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holidays.Domain.Users
{
    public sealed class Permission
    {
        public static readonly Permission UsersRead = new(1, "users:read");
        public int Id { get; init; }
        public string Name { get; init; }

        private Permission(int id, string name)
        {
            Id = id;
            Name = name;
        }

        private Permission()
        {
        }
    }
}

