using AutoMapper;
using CloverAce.Accounts;

namespace CloverAce;

public class CloverAceApplicationAutoMapperProfile : Profile
{
    public CloverAceApplicationAutoMapperProfile()
    {
        CreateMap<Account, AccountDto>();
    }
}
