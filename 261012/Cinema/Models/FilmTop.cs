using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Models
{
    internal sealed class FilmTop
    {
        public string Title { get; init; } = string.Empty;
        public int TicketsSold { get; init; }
    }
}
