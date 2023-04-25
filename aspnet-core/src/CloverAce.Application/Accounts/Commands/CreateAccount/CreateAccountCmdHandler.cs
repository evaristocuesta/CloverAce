using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CloverAce.Accounts.Commands.CreateAccount
{
    public class CreateAccountCmdHandler : IRequestHandler<CreateAccountCmd, CreateAccountCmdResponse>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly AccountManager _accountManager;
        private readonly IMapper _mapper;

        public CreateAccountCmdHandler(
            IAccountRepository accountRepository, 
            AccountManager accountManager, 
            IMapper mapper)
        {
            _accountRepository = accountRepository;
            _accountManager = accountManager;
            _mapper = mapper;
        }

        public async Task<CreateAccountCmdResponse> Handle(CreateAccountCmd request, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.InsertAsync(
                await _accountManager.CreateAsync(request.Name), 
                autoSave: true, 
                cancellationToken);

            return new CreateAccountCmdResponse { Account = _mapper.Map<AccountDto>(account) };
        }
    }
}
