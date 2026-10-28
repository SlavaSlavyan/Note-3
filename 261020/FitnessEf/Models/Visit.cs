using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessEf.Models
{
    internal sealed class Visit
    {
        public int VisitId { get; set; }
        public int ClientId { get; set; }
        public DateOnly VisitDate { get; set; }
        public string? Note { get; set; }

        public Client Client { get; set; } = null!;
    }
}
