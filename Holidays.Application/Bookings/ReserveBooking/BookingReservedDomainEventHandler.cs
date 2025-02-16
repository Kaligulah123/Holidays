﻿using Holidays.Application.Abstractions.Email;
using Holidays.Domain.Bookings;
using Holidays.Domain.Bookings.Events;
using Holidays.Domain.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holidays.Application.Bookings.ReserveBooking
{
    internal sealed class BookingReservedDomainEventHandler : INotificationHandler<BookingReservedDomainEvent>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;

        public BookingReservedDomainEventHandler(
            IBookingRepository bookingRepository,
            IUserRepository userRepository,
            IEmailService emailService)
        {
            _bookingRepository = bookingRepository;
            _userRepository = userRepository;
            _emailService = emailService;
        }

        public async Task Handle(BookingReservedDomainEvent notification, CancellationToken cancellationToken)
        {
            var booking = await _bookingRepository.GetByIdAsync(notification.BookingId, cancellationToken);

            if (booking is null)
            {
                return;
            }

            var user = await _userRepository.GetByIdAsync(booking.UserId, cancellationToken);

            if (user is null)
            {
                return;
            }

            await _emailService.SendAsync(
                user.Email,
                "Booking reserved!",
                "You have 10 minutes to confirm this booking");
        }
    }    
}
