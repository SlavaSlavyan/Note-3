using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Models
{
    internal sealed class ScreeningReport
    {
        public int ScreeningId { get; init; }
        public string FilmTitle { get; init; } = string.Empty;
        public DateTime StartsAt { get; init; }
        public string HallName { get; init; } = string.Empty;
        public int SoldTickets { get; init; }
        public decimal Revenue { get; init; }
    }
}
