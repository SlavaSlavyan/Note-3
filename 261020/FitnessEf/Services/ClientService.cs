using FitnessEf.Data;
using FitnessEf.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessEf.Services
{
    internal sealed class ClientService : IClientService
    {
        public async Task<List<Client>> GetAllAsync(CancellationToken ct = default)
        {
            await using var db = new FitnessContext();
            return await db.Clients
                .AsNoTracking()
                .OrderBy(c => c.ClientId)
                .ToListAsync(ct);
        }

        public async Task<List<ClientSummary>> GetProjectedAsync(CancellationToken ct = default)
        {
            await using var db = new FitnessContext();
            return await db.Clients
                .AsNoTracking()
                .OrderBy(c => c.LastName)
                .ThenBy(c => c.FirstName)
                .Select(c => new ClientSummary(
                    c.ClientId,
                    c.FirstName + " " + c.LastName,
                    c.Phone))
                .ToListAsync(ct);
        }

        public async Task<List<Client>> GetActiveAsync(CancellationToken ct = default)
        {
            await using var db = new FitnessContext();
            return await db.Clients
                .AsNoTracking()
                .Where(c => c.Status == "active")
                .OrderBy(c => c.LastName)
                .ToListAsync(ct);
        }

        public async Task<Client?> FindByIdAsync(int id, CancellationToken ct = default)
        {
            await using var db = new FitnessContext();
            return await db.Clients.FindAsync(new object?[] { id }, ct);
        }

        public async Task<List<Client>> SearchByLastNameAsync(string term, CancellationToken ct = default)
        {
            await using var db = new FitnessContext();
            return await db.Clients
                .AsNoTracking()
                .Where(c => c.LastName.Contains(term))
                .OrderBy(c => c.LastName)
                .ToListAsync(ct);
        }

        public async Task<List<Client>> GetPageAsync(int page, int pageSize, CancellationToken ct = default)
        {
            if (page < 1) throw new ArgumentOutOfRangeException(nameof(page));
            if (pageSize < 1) throw new ArgumentOutOfRangeException(nameof(pageSize));

            await using var db = new FitnessContext();
            return await db.Clients
                .AsNoTracking()
                .OrderBy(c => c.ClientId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(ct);
        }

        public async Task<Client> AddAsync(Client client, CancellationToken ct = default)
        {
            await using var db = new FitnessContext();
            db.Clients.Add(client);
            await db.SaveChangesAsync(ct);
            return client;
        }

        public async Task<bool> UpdatePhoneAsync(int id, string phone, CancellationToken ct = default)
        {
            await using var db = new FitnessContext();
            var client = await db.Clients.FindAsync(new object?[] { id }, ct);
            if (client is null) return false;

            client.Phone = phone;
            await db.SaveChangesAsync(ct);
            return true;
        }

        public async Task<bool> UpdateStatusAsync(int id, string status, CancellationToken ct = default)
        {
            await using var db = new FitnessContext();
            var client = await db.Clients.FindAsync(new object?[] { id }, ct);
            if (client is null) return false;

            client.Status = status;
            await db.SaveChangesAsync(ct);
            return true;
        }

        public async Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            await using var db = new FitnessContext();
            var client = await db.Clients.FindAsync(new object?[] { id }, ct);
            if (client is null) return DeleteResult.NotFound;

            // Дружелюбная предпроверка: FK в БД всё равно защищает от гонок.
            bool hasVisits = await db.Visits.AnyAsync(v => v.ClientId == id, ct);
            if (hasVisits) return DeleteResult.HasRelatedVisits;

            db.Clients.Remove(client);
            await db.SaveChangesAsync(ct);
            return DeleteResult.Deleted;
        }
    }
}
