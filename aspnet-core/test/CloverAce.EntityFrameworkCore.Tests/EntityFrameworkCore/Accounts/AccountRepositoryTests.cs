using CloverAce.Accounts;
using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CloverAce.EntityFrameworkCore.Accounts;

public class AccountRepositoryTests : CloverAceEntityFrameworkCoreTestBase
{
    private readonly IAccountRepository _accountRepository;
    private readonly AccountManager _accountManager;

    public AccountRepositoryTests()
    {
        _accountRepository = GetRequiredService<IAccountRepository>();
        _accountManager = GetRequiredService<AccountManager>();
    }

    [Fact]
    public async Task Should_Exist()
    {
        await WithUnitOfWorkAsync(async () =>
        {
            // Act
            var exists = await _accountRepository.ExistsAsync("ING Direct", default);

            // Assert
            exists.ShouldBeTrue();
        });
    }

    [Fact]
    public async Task Should_Get_All_Accounts()
    {
        // Act
        var accounts = await _accountRepository.GetListAsync();

        // Assert
        accounts.Count.ShouldBe(2);
        accounts[0].Name.ShouldBe("ING Direct");
        accounts[1].Name.ShouldBe("Evo Bank");
    }

    [Fact]
    public async Task Should_Create_A_New_Accout()
    {
        // Act
        var account = await _accountRepository.InsertAsync(
            await _accountManager.CreateAsync("BBVA", default), 
            true);

        // Assert
        var checkAccount = await _accountRepository.GetAsync(account.Id);
        checkAccount.ShouldNotBeNull();
        checkAccount.Id.ShouldBe(account.Id);
        checkAccount.Name.ShouldBe(account.Name);
    }
}
