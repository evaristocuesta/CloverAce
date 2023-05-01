using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CloverAce.Accounts.Commands.DeleteAccount;

public class DeleteAccountCmdHandler : IRequestHandler<DeleteAccountCmd>
{
    private readonly IAccountRepository _accountRepository;

    public DeleteAccountCmdHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task Handle(DeleteAccountCmd request, CancellationToken cancellationToken)
    {
        var account = await _accountRepository.GetAsync(request.AccountId, includeDetails: false, cancellationToken);
        await _accountRepository.DeleteAsync(account, autoSave: true, cancellationToken);
    }
}
