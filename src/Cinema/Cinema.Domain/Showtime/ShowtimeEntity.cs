﻿
using Cinema.Domain.AuditoriumDefinition;

namespace Cinema.Domain.Showtime;
public class ShowtimeEntity
{
    public static ShowtimeEntity Create(AuditoriumEntity auditorium, MovieEntity movie, DateTime sessionDate)
    {
        var showtimeId = Guid.NewGuid();

        return new ShowtimeEntity
        {
            Id = showtimeId,
            Movie = movie,
            Seats = auditorium.Seats.Select(x => ShowtimeSeatEntity.Create(x, showtimeId)),
            AuditoriumId = auditorium.Id,
            SessionDate = sessionDate
        };
    }

    public static void ReserveSeats(IEnumerable<ShowtimeSeatEntity> showtimeSeats)
    {

        //Contiguous for same row?
        var seatsRow = showtimeSeats.First().Seat.RowNumber;
        if (!showtimeSeats.Select(x => x.Seat).All(x => x.RowNumber == seatsRow))
            throw new InvalidOperationException("Just select seats from a single row");


        var seatNumbers = showtimeSeats.Select(x => x.Seat).Select(x => x.SeatNumber).ToArray();
        Array.Sort(seatNumbers);

        for (int i = 1; i < seatNumbers.Length; i++)
            if (seatNumbers[i] - seatNumbers[i - 1] > 1)
                throw new InvalidOperationException("Seat numbers not contiguous");


        foreach (var seat in showtimeSeats)
            seat.SetReserved();

    }

    public Guid Id { get; private set; }
    public int AuditoriumId { get; private set; }
    public IEnumerable<ShowtimeSeatEntity> Seats { get; private set; } = Enumerable.Empty<ShowtimeSeatEntity>();

    public Guid MovieId { get; private set; }
    public MovieEntity Movie { get; private set; }
    public DateTime SessionDate { get; private set; }

}
