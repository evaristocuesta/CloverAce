using JetBrains.Annotations;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace CloverAce.Accounts;

public class AccountManager : DomainService
{
    private readonly IAccountRepository _accountRepository;

    public AccountManager(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<Account> CreateAsync([NotNull] string name)
    {
        Check.NotNullOrWhiteSpace(name, nameof(name));

        var accountExists = await _accountRepository.ExistsAsync(name);

        if (accountExists)
        {
            throw new AccountAlreadyExistsException(name);
        }

        return new Account(GuidGenerator.Create(), name);
    }

    public async Task ChangeNameAsync([NotNull] Account account, [NotNull] string name)
    {
        Check.NotNull(account, nameof(account));
        Check.NotNullOrWhiteSpace(name, nameof(name));

        var existingAccount = await _accountRepository.ExistsOtherAsync(account.Id, name);

        if (existingAccount) 
        {
            throw new AccountAlreadyExistsException(name);
        }

        account.Name = name;
    }
}
