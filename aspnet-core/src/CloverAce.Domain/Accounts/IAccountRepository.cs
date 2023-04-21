using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace CloverAce.Accounts;

public interface IAccountRepository : IRepository<Account, Guid>
{
    Task<bool> ExistsAsync(string name);
    Task<bool> ExistsOtherAsync(Guid id, string name);
}
