using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CloverAce.Accounts;

public class AccountDomainTests : CloverAceDomainTestBase
{
    private readonly AccountManager _accountManager;

    public AccountDomainTests()
    {
        _accountManager = GetRequiredService<AccountManager>();
    }

    [Fact]
    public async Task Should_Not_Allow_To_Create_Duplicate_Account()
    {
        await Assert.ThrowsAsync<AccountAlreadyExistsException>(async () =>
        {
            await _accountManager.CreateAsync("ING Direct");
        });
    }

    [Fact]
    public async Task Should_Create_Account()
    {
        // Act
        var account = await _accountManager.CreateAsync("BBVA");

        // Assert
        account.ShouldNotBeNull();
        account.Id.ShouldNotBe(Guid.Empty);
        account.Name.ShouldBe("BBVA");
    }

    [Fact]
    public async Task Should_Not_Allow_To_Change_Duplicate_Name_Account()
    {
        await Assert.ThrowsAsync<AccountAlreadyExistsException>(async () =>
        {
            // Arrange
            var bbva = await _accountManager.CreateAsync("BBVA");

            // Act
            await _accountManager.ChangeNameAsync(bbva, "ING Direct");
        });
    }

    [Fact]
    public async Task Should_Change_Name_Account()
    {
        // Arrange
        var bbva = await _accountManager.CreateAsync("BBVA");

        // Act
        await _accountManager.ChangeNameAsync(bbva, "Caixa Bank");

        // Assert
        bbva.ShouldNotBeNull();
        bbva.Id.ShouldNotBe(Guid.Empty);
        bbva.Name.ShouldBe("Caixa Bank");
    }
}
