using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Models
{
    internal sealed class CustomerTicket
    {
        public int TicketId { get; init; }
        public string FilmTitle { get; init; } = string.Empty;
        public DateTime StartsAt { get; init; }
        public string HallName { get; init; } = string.Empty;
        public int SeatNumber { get; init; }
        public decimal Price { get; init; }
        public string Status { get; init; } = string.Empty;
    }
}
