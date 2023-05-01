using CloverAce.Accounts.Commands.UpdateAccount;
using Shouldly;
using System;
using System.Threading.Tasks;
using Volo.Abp.AutoMapper;
using Volo.Abp.Domain.Entities;
using Xunit;

namespace CloverAce.Accounts;

public class UpdateAccountApplicationTests : CloverAceApplicationTestBase
{
    private readonly UpdateAccountCmdHandler _updateAccountCmdHandler;
    private readonly IAccountRepository _accountRepository;
    private readonly AccountManager _accountManager;
    private readonly IMapperAccessor _mapperAccessor;

    public UpdateAccountApplicationTests()
    {
        _accountRepository = GetRequiredService<IAccountRepository>();
        _accountManager = GetRequiredService<AccountManager>();
        _mapperAccessor = GetRequiredService<IMapperAccessor>();

        _updateAccountCmdHandler = new UpdateAccountCmdHandler(
            _accountRepository,
            _accountManager,
            _mapperAccessor);
    }

    [Fact]
    public async Task Should_Update_Account()
    {
        // Arrange
        var account = await _accountRepository.GetAsync(a => a.Name == "ING Direct");
        
        var cmd = new UpdateAccountCmd
        {
            AccountId = account.Id,
            Name = "ING Direct Update"
        };

        // Act
        var response = await _updateAccountCmdHandler.Handle(cmd, default);

        // Assert
        response.ShouldNotBeNull();
        response.Name.ShouldBe(cmd.Name);
    }

    [Fact]
    public async Task Should_Not_Allow_To_Update_With_Existing_Account_Name()
    {
        await Assert.ThrowsAsync<AccountAlreadyExistsException>(async () =>
        {
            // Arrange
            var account = await _accountRepository.GetAsync(a => a.Name == "ING Direct");

            var cmd = new UpdateAccountCmd
            {
                AccountId = account.Id,
                Name = "Evo Bank"
            };

            // Act
            _ = await _updateAccountCmdHandler.Handle(cmd, default);
        });
    }

    [Fact]
    public async Task Should_Not_Found_Account_To_Update()
    {
        await Assert.ThrowsAsync<EntityNotFoundException>(async () =>
        {
            var cmd = new UpdateAccountCmd
            {
                AccountId = Guid.NewGuid(),
                Name = "Evo Bank"
            };

            // Act
            _ = await _updateAccountCmdHandler.Handle(cmd, default);
        });
    }
}
