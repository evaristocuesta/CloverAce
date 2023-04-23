using CloverAce.Accounts;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace CloverAce;
public class CloverAceDataSeederContributor
    : IDataSeedContributor, ITransientDependency
{
    private readonly IAccountRepository _accountRepository;
    private readonly AccountManager _accountManager;

    public CloverAceDataSeederContributor(
        IAccountRepository accountRepository, 
        AccountManager accountManager)
    {
        _accountRepository = accountRepository;
        _accountManager = accountManager;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _accountRepository.GetCountAsync() > 0) 
        {
            return;
        }

        _ = await _accountRepository.InsertAsync(
            await _accountManager.CreateAsync("ING Direct"));
        _ = await _accountRepository.InsertAsync(
            await _accountManager.CreateAsync("Evo Bank"));
    }
}
