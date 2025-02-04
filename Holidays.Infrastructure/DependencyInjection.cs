using Dapper;
using Holidays.Application.Abstractions.Clock;
using Holidays.Application.Abstractions.Data;
using Holidays.Application.Abstractions.Email;
using Holidays.Domain.Abstractions;
using Holidays.Domain.Apartments;
using Holidays.Domain.Bookings;
using Holidays.Domain.Reviews;
using Holidays.Domain.Users;
using Holidays.Infrastructure.Clock;
using Holidays.Infrastructure.Data;
using Holidays.Infrastructure.Email;
using Holidays.Infrastructure.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holidays.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDateTimeProvider, DateTimeProvider>();

            services.AddTransient<IEmailService, EmailService>();

            AddPersistence(services, configuration);

            return services;
        }

        private static void AddPersistence(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("sqlConnection")  ??
                                    throw new ArgumentNullException(nameof(configuration));

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddSingleton<ISqlConnectionFactory>(_ =>
            new SqlConnectionFactory(connectionString));

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IApartmentRepository, ApartmentRepository>();

            services.AddScoped<IBookingRepository, BookingRepository>();

            services.AddScoped<IReviewRepository, ReviewRepository>();

            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());            

            SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());
            
        }
    }
}
