using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Models
{
    internal sealed class Film
    {
        public int FilmId { get; init; }
        public string Title { get; init; } = string.Empty;
        public string Genre { get; init; } = string.Empty;
        public int DurationMinutes { get; init; }
        public int AgeRating { get; init; }
        public int ReleaseYear { get; init; }
        public string? Description { get; init; }
    }
}
