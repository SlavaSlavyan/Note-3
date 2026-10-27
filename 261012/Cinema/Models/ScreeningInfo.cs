using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Models
{
    internal sealed class ScreeningInfo
    {
        public int ScreeningId { get; init; }
        public string FilmTitle { get; init; } = string.Empty;
        public string Genre { get; init; } = string.Empty;
        public DateTime StartsAt { get; init; }
        public string HallName { get; init; } = string.Empty;
        public decimal TicketPrice { get; init; }
        public int TotalSeats { get; init; }
        public int FreeSeats { get; init; }
    }
}
