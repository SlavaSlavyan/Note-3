using FitnessEf.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessEf.Services
{
    internal sealed record ClientSummary(int ClientId, string FullName, string? Phone);
    internal enum DeleteResult
    {
        Deleted,
        NotFound,
        HasRelatedVisits
    }

    internal interface IClientService
    {
        Task<List<Client>> GetAllAsync(CancellationToken ct = default);
        Task<List<ClientSummary>> GetProjectedAsync(CancellationToken ct = default);
        Task<List<Client>> GetActiveAsync(CancellationToken ct = default);
        Task<Client?> FindByIdAsync(int id, CancellationToken ct = default);
        Task<List<Client>> SearchByLastNameAsync(string term, CancellationToken ct = default);
        Task<List<Client>> GetPageAsync(int page, int pageSize, CancellationToken ct = default);

        Task<Client> AddAsync(Client client, CancellationToken ct = default);
        Task<bool> UpdatePhoneAsync(int id, string phone, CancellationToken ct = default);
        Task<bool> UpdateStatusAsync(int id, string status, CancellationToken ct = default);
        Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default);
    }
}
