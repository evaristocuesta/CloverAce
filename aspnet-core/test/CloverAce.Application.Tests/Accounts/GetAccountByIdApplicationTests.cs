using CloverAce.Accounts.Commands.DeleteAccount;
using CloverAce.Accounts.Queries.GetAccountById;
using Shouldly;
using System;
using System.Threading.Tasks;
using Volo.Abp.AutoMapper;
using Volo.Abp.Domain.Entities;
using Xunit;

namespace CloverAce.Accounts;

public class GetAccountByIdApplicationTests : CloverAceApplicationTestBase
{
    private readonly GetAccountByIdCmdHandler _getAccountCmdHandler;
    private readonly IAccountRepository _accountRepository;
    private readonly IMapperAccessor _mapperAccessor;

    public GetAccountByIdApplicationTests()
    {
        _accountRepository = GetRequiredService<IAccountRepository>();
        _mapperAccessor = GetRequiredService<IMapperAccessor>();

        _getAccountCmdHandler = new GetAccountByIdCmdHandler(
            _accountRepository,
            _mapperAccessor);
    }

    [Fact]
    public async Task Should_Return_Accounts()
    {
        // Arrange
        var account = await _accountRepository.GetAsync(a => a.Name == "ING Direct");

        var cmd = new GetAccountByIdCmd
        {
            AccountId = account.Id
        };

        // Act
        var response = await _getAccountCmdHandler.Handle(cmd, default);

        // Assert
        response.ShouldNotBeNull();
        response.Name.ShouldBe("ING Direct");
    }

    [Fact]
    public async Task Should_Not_Found_Account()
    {
        await Assert.ThrowsAsync<EntityNotFoundException>(async () =>
        {
            var cmd = new GetAccountByIdCmd
            {
                AccountId = Guid.NewGuid()
            };

            // Act
            await _getAccountCmdHandler.Handle(cmd, default);
        });
    }
}
