using Holidays.Application.Abstractions.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holidays.Infrastructure.Email
{
    public sealed class EmailService : IEmailService
    {
        public Task SendAsync(Domain.Users.Email recipient, string subject, string body)
        {
            return Task.CompletedTask;
        }
    }
}
