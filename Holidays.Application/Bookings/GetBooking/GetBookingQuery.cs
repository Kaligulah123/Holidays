﻿using Holidays.Application.Abstractions.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holidays.Application.Bookings.GetBooking
{
    public sealed record GetBookingQuery(Guid BookingId) : ICachedQuery<BookingResponse>
    {
        public string CacheKey => $"bookings-{BookingId}";
        public TimeSpan? Expiration =>null;
    }
}
