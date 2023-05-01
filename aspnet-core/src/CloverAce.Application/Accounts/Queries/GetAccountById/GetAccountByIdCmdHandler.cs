using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.AutoMapper;

namespace CloverAce.Accounts.Queries.GetAccountById;

public class GetAccountByIdCmdHandler : IRequestHandler<GetAccountByIdCmd, AccountDto>
{
    private readonly IAccountRepository _accountRepository;
    private readonly IMapper _mapper;

    public GetAccountByIdCmdHandler(
        IAccountRepository accountRepository,
        IMapperAccessor mapper)
    {
        _accountRepository = accountRepository;
        _mapper = mapper.Mapper;
    }

    public async Task<AccountDto> Handle(GetAccountByIdCmd request, CancellationToken cancellationToken)
    {
        var account = await _accountRepository.GetAsync(
            request.AccountId,
            includeDetails: false,
            cancellationToken);

        return _mapper.Map<AccountDto>(account);
    }
}
