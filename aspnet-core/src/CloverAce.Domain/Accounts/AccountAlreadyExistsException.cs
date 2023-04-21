using Volo.Abp;

namespace CloverAce.Accounts;

public class AccountAlreadyExistsException : BusinessException
{
    public AccountAlreadyExistsException(string name) :base (CloverAceDomainErrorCodes.AccountAlreadyExists)
    { 
        WithData("name", name);
    }
}
