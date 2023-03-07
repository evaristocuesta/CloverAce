using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace CloverAce.Accounts
{
    public class AccountManager : DomainService
    {
        private readonly IRepository<Account> _accountRepository;

        public AccountManager(IRepository<Account> accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Account> CreateAsync([NotNull] string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var accountExists = await _accountRepository.AnyAsync(x => x.Name == name);

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

            var existingAccount = await _accountRepository.FindAsync(x => x.Name == name && x.Id != account.Id);

            if (existingAccount != null) 
            {
                throw new AccountAlreadyExistsException(name);
            }

            account.Name = name;
        }
    }
}
