using JetBrains.Annotations;
using System.Threading;
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

    public async Task<Account> CreateAsync([NotNull] string name, CancellationToken cancellationToken)
    {
        Check.NotNullOrWhiteSpace(name, nameof(name), maxLength: AccountsConsts.MaxNameLength);

        var accountExists = await _accountRepository.ExistsAsync(name, cancellationToken);

        if (accountExists)
        {
            throw new AccountAlreadyExistsException(name);
        }

        return new Account(GuidGenerator.Create(), name);
    }

    public async Task ChangeNameAsync([NotNull] Account account, [NotNull] string name, CancellationToken cancellationToken)
    {
        Check.NotNull(account, nameof(account));
        Check.NotNullOrWhiteSpace(name, nameof(name), maxLength: AccountsConsts.MaxNameLength);

        var existingAccount = await _accountRepository.ExistsOtherAsync(account.Id, name, cancellationToken);

        if (existingAccount) 
        {
            throw new AccountAlreadyExistsException(name);
        }

        account.Name = name;
    }
}
