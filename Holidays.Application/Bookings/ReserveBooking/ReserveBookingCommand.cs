﻿using Holidays.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holidays.Application.Bookings.ReserveBooking
{
    public record ReserveBookingCommand(
       Guid ApartmentId,
       Guid UserId,
       DateOnly StartDate,
       DateOnly EndDate) : ICommand<Guid>;
}
