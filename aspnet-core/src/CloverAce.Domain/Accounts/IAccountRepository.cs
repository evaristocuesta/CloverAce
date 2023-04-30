using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace CloverAce.Accounts;

public interface IAccountRepository : IRepository<Account, Guid>
{
    Task<bool> ExistsAsync(string name, CancellationToken cancellationToken);
    Task<bool> ExistsOtherAsync(Guid id, string name, CancellationToken cancellationToken);
}
