using CloverAce.Accounts.Commands.CreateAccount;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.AutoMapper;
using Xunit;

namespace CloverAce.Accounts;

public class AccountApplicationTests : CloverAceApplicationTestBase
{
    private readonly CreateAccountCmdHandler _createAccountCmdHandler;
    private readonly IAccountRepository _accountRepository;
    private readonly AccountManager _accountManager;
    private readonly IMapperAccessor _mapperAccessor;

    public AccountApplicationTests()
    {
        _accountRepository = GetRequiredService<IAccountRepository>();
        _accountManager = GetRequiredService<AccountManager>();
        _mapperAccessor = GetRequiredService<IMapperAccessor>();

        _createAccountCmdHandler = new CreateAccountCmdHandler(
            _accountRepository,
            _accountManager,
            _mapperAccessor);
    }

    [Fact]
    public async Task Shoul_Create_Account()
    {
        // Arrange
        var cmd = new CreateAccountCmd
        {
            Name = "New Account"
        };

        // Act
        var response = await _createAccountCmdHandler.Handle(cmd, default);

        // Assert
        response.Account.ShouldNotBeNull();
        response.Account.Name.ShouldBe(cmd.Name);
    }

    [Fact]
    public async Task Shoul_Not_Allow_To_Create_Duplicate_Account()
    {
        await Assert.ThrowsAsync<AccountAlreadyExistsException>(async () =>
        {
            // Arrange
            var cmd = new CreateAccountCmd
            {
                Name = "ING Direct"
            };

            // Act
            _ = await _createAccountCmdHandler.Handle(cmd, default);
        });
    }
}
