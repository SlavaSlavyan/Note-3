using FitnessEf.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessEf.Services
{
    internal enum AddVisitResult
    {
        Added,
        ClientNotFound
    }
    internal interface IVisitService
    {
        Task<List<Client>> GetClientsWithVisitsAsync(CancellationToken ct = default);
        Task<AddVisitResult> AddVisitAsync(int clientId, DateOnly visitDate, string? note, CancellationToken ct = default);
    }
}
