using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Results
{
    internal sealed class CancelResult
    {
        public CancelStatus Status { get; private init; }

        public static CancelResult Success() => new() { Status = CancelStatus.Success };
        public static CancelResult NotFound() => new() { Status = CancelStatus.NotFound };
        public static CancelResult AlreadyCancelled() => new() { Status = CancelStatus.AlreadyCancelled };
    }
}