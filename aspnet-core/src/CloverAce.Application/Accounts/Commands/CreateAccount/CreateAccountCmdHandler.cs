using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.AutoMapper;

namespace CloverAce.Accounts.Commands.CreateAccount;

public class CreateAccountCmdHandler : IRequestHandler<CreateAccountCmd, AccountDto>
{
    private readonly IAccountRepository _accountRepository;
    private readonly AccountManager _accountManager;
    private readonly IMapper _mapper;

    public CreateAccountCmdHandler(
        IAccountRepository accountRepository, 
        AccountManager accountManager, 
        IMapperAccessor mapper)
    {
        _accountRepository = accountRepository;
        _accountManager = accountManager;
        _mapper = mapper.Mapper;
    }

    public async Task<AccountDto> Handle(CreateAccountCmd request, CancellationToken cancellationToken)
    {
        var account = await _accountManager.CreateAsync(request.Name, cancellationToken);

        await _accountRepository.InsertAsync(
            account, 
            autoSave: true, 
            cancellationToken);

        return _mapper.Map<AccountDto>(account);
    }
}
