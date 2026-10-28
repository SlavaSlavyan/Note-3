using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessEf.Services
{
    internal sealed record ClientStatistics(int Total, int Active, bool HasInactive);
    internal interface IStatisticsService
    {
        Task<ClientStatistics> GetAsync(CancellationToken ct = default);
    }
}
