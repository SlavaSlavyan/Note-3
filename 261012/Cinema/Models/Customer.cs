using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Models
{
    internal sealed class Customer
    {
        public int CustomerId { get; init; }
        public string FirstName { get; init; } = string.Empty;
        public string LastName { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public string? Phone { get; init; }
        public DateTime RegisteredAt { get; init; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
