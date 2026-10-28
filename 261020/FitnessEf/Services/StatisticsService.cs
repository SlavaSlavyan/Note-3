using FitnessEf.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace FitnessEf.Services
{
    internal sealed class StatisticsService : IStatisticsService
    {
        public async Task<ClientStatistics> GetAsync(CancellationToken ct = default)
        {
            await using var db = new FitnessContext();

            int total = await db.Clients.CountAsync(ct);
            int active = await db.Clients.CountAsync(c => c.Status == "active", ct);
            bool hasInactive = await db.Clients.AnyAsync(c => c.Status == "inactive", ct);

            return new ClientStatistics(total, active, hasInactive);
        }
    }
}
