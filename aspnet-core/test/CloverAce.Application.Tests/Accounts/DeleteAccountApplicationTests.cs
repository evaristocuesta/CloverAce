using CloverAce.Accounts.Commands.DeleteAccount;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Xunit;

namespace CloverAce.Accounts;

public class DeleteAccountApplicationTests : CloverAceApplicationTestBase
{
    private readonly DeleteAccountCmdHandler _deleteAccountCmdHandler;
    private readonly IAccountRepository _accountRepository;

    public DeleteAccountApplicationTests()
    {
        _accountRepository = GetRequiredService<IAccountRepository>();

        _deleteAccountCmdHandler = new DeleteAccountCmdHandler(
            _accountRepository);
    }

    [Fact]
    public async Task Should_Delete_Account()
    {
        // Arrange
        var account = await _accountRepository.GetAsync(a => a.Name == "ING Direct");
        var cmd = new DeleteAccountCmd { AccountId = account.Id };

        // Act
        await _deleteAccountCmdHandler.Handle(cmd, default);

        // Assert
        await Assert.ThrowsAsync<EntityNotFoundException>(async () =>
        {
            _ = await _accountRepository.GetAsync(cmd.AccountId);
        });
    }

    [Fact]
    public async Task Should_Not_Found_Account_To_Delete()
    { 
        await Assert.ThrowsAsync<EntityNotFoundException>(async () =>
        {
            var cmd = new DeleteAccountCmd
            {
                AccountId = Guid.NewGuid()
            };

            // Act
            await _deleteAccountCmdHandler.Handle(cmd, default);
        });
    }
}
