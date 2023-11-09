﻿namespace VacationRental.ServiceBus.IntegrationEvents
{
    public class BookingConfirmedIntegrationEvent : IntegrationEvent
    {
        public int RentalId { get; set; }
        public int BookingId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}