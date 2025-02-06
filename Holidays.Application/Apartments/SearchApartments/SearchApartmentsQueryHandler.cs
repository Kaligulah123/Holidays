using Dapper;
using Holidays.Application.Abstractions.Data;
using Holidays.Application.Abstractions.Messaging;
using Holidays.Domain.Abstractions;
using Holidays.Domain.Apartments;
using Holidays.Domain.Bookings;
using Holidays.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Holidays.Application.Apartments.SearchApartments
{
    internal sealed class SearchApartmentsQueryHandler : IQueryHandler<SearchApartmentsQuery, IReadOnlyList<ApartmentResponse>>
    {
        private static readonly int[] ActiveBookingStatuses = {
        (int)BookingStatus.Reserved,
        (int)BookingStatus.Confirmed,
        (int)BookingStatus.Completed
        };

        private readonly ISqlConnectionFactory _sqlConnectionFactory;


        public SearchApartmentsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }


        public async Task<Result<IReadOnlyList<ApartmentResponse>>> Handle(SearchApartmentsQuery request, CancellationToken cancellationToken)
        {
            if (request.StartDate > request.EndDate)
            {
                return new List<ApartmentResponse>();
            }

            using var connection = _sqlConnectionFactory.CreateConnection();

            const string sql = """
                        SELECT
                            a.Id AS Id,
                            a.Name AS Name,
                            a.Description AS Description,
                            a.Price_Amount AS Price,
                            a.Price_Currency AS Currency,
                            a.Address_Country AS Country,
                            a.Address_State AS State,
                            a.Address_ZipCode AS ZipCode,
                            a.Address_City AS City,
                            a.Address_Street AS Street
                        FROM apartments AS a
                        WHERE NOT EXISTS
                        (
                            SELECT 1
                            FROM bookings AS b
                            WHERE
                                b.ApartmentId = a.Id AND
                                b.Duration_Start <= @EndDate AND
                                b.Duration_End >= @StartDate
                                AND b.Status IN @Statuses
                        )
                        """;

            var parameters = new DynamicParameters();
            parameters.Add("StartDate", request.StartDate);
            parameters.Add("EndDate", request.EndDate);
            parameters.Add("Statuses", ActiveBookingStatuses);

            var apartments = await connection
                .QueryAsync<ApartmentResponse, AddressResponse, ApartmentResponse>(
                    sql,
                    (apartment, address) =>
                    {
                        apartment.Address = address;
                        return apartment;
                    },
                    parameters,
                    splitOn: "Country");

            return apartments.ToList();
        }
  
    }
}
