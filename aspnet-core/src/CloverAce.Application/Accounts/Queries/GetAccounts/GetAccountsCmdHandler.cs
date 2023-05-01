using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.AutoMapper;

namespace CloverAce.Accounts.Queries.GetAccounts;

public class GetAccountsCmdHandler : IRequestHandler<GetAccountsCmd, IEnumerable<AccountDto>>
{
    private readonly IAccountRepository _accountRepository;
    private readonly IMapper _mapper;

    public GetAccountsCmdHandler(
        IAccountRepository accountRepository,
        IMapperAccessor mapper)
    {
        _accountRepository = accountRepository;
        _mapper = mapper.Mapper;
    }

    public async Task<IEnumerable<AccountDto>> Handle(GetAccountsCmd request, CancellationToken cancellationToken)
    {
        var accounts = await _accountRepository.GetListAsync(
            includeDetails: false, 
            cancellationToken);

        return _mapper.Map<IEnumerable<AccountDto>>(accounts);
    }
}
