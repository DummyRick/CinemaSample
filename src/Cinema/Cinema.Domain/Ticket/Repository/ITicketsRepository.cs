﻿using Cinema.Domain.Showtime;

namespace Cinema.Domain.Ticket.Repository
{
    public interface ITicketsRepository
    {
        Task<TicketEntity> ConfirmPaymentAsync(TicketEntity ticket, CancellationToken cancel);
        Task<TicketEntity> CreateAsync(ShowtimeEntity showtime, IEnumerable<SeatEntity> selectedSeats, CancellationToken cancel);
        Task<TicketEntity> GetAsync(Guid id, CancellationToken cancel);
        Task<IEnumerable<TicketEntity>> GetEnrichedAsync(int showtimeId, CancellationToken cancel);
    }
}