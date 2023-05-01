using CloverAce.Accounts.Queries.GetAccounts;
using Shouldly;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AutoMapper;
using Xunit;

namespace CloverAce.Accounts;

public class GetAccountsApplicationTests : CloverAceApplicationTestBase
{
    private readonly GetAccountsCmdHandler _getAccountsCmdHandler;
    private readonly IAccountRepository _accountRepository;
    private readonly IMapperAccessor _mapperAccessor;

    public GetAccountsApplicationTests()
    {
        _accountRepository = GetRequiredService<IAccountRepository>();
        _mapperAccessor = GetRequiredService<IMapperAccessor>();

        _getAccountsCmdHandler = new GetAccountsCmdHandler(
            _accountRepository,
            _mapperAccessor);
    }

    [Fact]
    public async Task Should_Return_Accounts()
    {
        // Arrange
        var cmd = new GetAccountsCmd();

        // Act
        var response = await _getAccountsCmdHandler.Handle(cmd, default);

        // Assert
        response.ShouldNotBeNull();
        response.Count().ShouldBe(2);
    }
}
