using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.AutoMapper;

namespace CloverAce.Accounts.Commands.UpdateAccount;

public class UpdateAccountCmdHandler : IRequestHandler<UpdateAccountCmd, AccountDto>
{
    private readonly IAccountRepository _accountRepository;
    private readonly AccountManager _accountManager;
    private readonly IMapper _mapper;

    public UpdateAccountCmdHandler(
        IAccountRepository accountRepository,
        AccountManager accountManager,
        IMapperAccessor mapper)
    {
        _accountRepository = accountRepository;
        _accountManager = accountManager;
        _mapper = mapper.Mapper;
    }

    public async Task<AccountDto> Handle(UpdateAccountCmd request, CancellationToken cancellationToken)
    {
        var account = await _accountRepository.GetAsync(request.AccountId, includeDetails: false, cancellationToken);
        await _accountManager.ChangeNameAsync(account, request.Name, cancellationToken);
        await _accountRepository.UpdateAsync(account, autoSave: true, cancellationToken);
        return _mapper.Map<AccountDto>(account);
    }
}
