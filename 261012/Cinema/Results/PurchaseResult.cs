using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Results
{
    internal sealed class PurchaseResult
    {
        public bool IsSuccess { get; private init; }
        public string? ErrorMessage { get; private init; }

        public int TicketId { get; private init; }
        public string FilmTitle { get; private init; } = string.Empty;
        public DateTime StartsAt { get; private init; }
        public int SeatNumber { get; private init; }
        public decimal Price { get; private init; }

        public static PurchaseResult Success(int ticketId, string filmTitle, DateTime startsAt, int seatNumber, decimal price) =>
            new()
            {
                IsSuccess = true,
                TicketId = ticketId,
                FilmTitle = filmTitle,
                StartsAt = startsAt,
                SeatNumber = seatNumber,
                Price = price
            };

        public static PurchaseResult Error(string message) =>
            new() { IsSuccess = false, ErrorMessage = message };
    }
}
