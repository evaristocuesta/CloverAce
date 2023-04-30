using CloverAce.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace CloverAce.Accounts;

public class EFCoreAccountRepository : EfCoreRepository<CloverAceDbContext, Account, Guid>, IAccountRepository
{
    public EFCoreAccountRepository(IDbContextProvider<CloverAceDbContext> dbContextProvider) 
        : base(dbContextProvider)
    {
    }

    public async Task<bool> ExistsAsync(string name)
    {
        var accounts = await GetDbSetAsync();
        return await accounts.AnyAsync(x => x.Name.Equals(name));
    }

    public async Task<bool> ExistsOtherAsync(Guid id, string name)
    {
        var accounts = await GetDbSetAsync();
        return await accounts.AnyAsync(x => x.Id != id && x.Name.Equals(name));
    }
}
