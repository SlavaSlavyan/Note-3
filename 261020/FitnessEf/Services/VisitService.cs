using FitnessEf.Data;
using FitnessEf.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessEf.Services
{
    internal sealed class VisitService : IVisitService
    {
        public async Task<List<Client>> GetClientsWithVisitsAsync(CancellationToken ct = default)
        {
            await using var db = new FitnessContext();
            return await db.Clients
                .AsNoTracking()
                .Include(c => c.Visits)
                .OrderBy(c => c.ClientId)
                .ToListAsync(ct);
        }

        public async Task<AddVisitResult> AddVisitAsync(
            int clientId,
            DateOnly visitDate,
            string? note,
            CancellationToken ct = default)
        {
            await using var db = new FitnessContext();

            bool exists = await db.Clients.AnyAsync(c => c.ClientId == clientId, ct);
            if (!exists) return AddVisitResult.ClientNotFound;

            db.Visits.Add(new Visit
            {
                ClientId = clientId,
                VisitDate = visitDate,
                Note = note
            });

            await db.SaveChangesAsync(ct);
            return AddVisitResult.Added;
        }
    }
}
