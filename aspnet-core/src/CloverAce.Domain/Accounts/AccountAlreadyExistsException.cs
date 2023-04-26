using System;
using System.Runtime.Serialization;
using Volo.Abp;

namespace CloverAce.Accounts;

[Serializable]
public class AccountAlreadyExistsException : BusinessException
{
    public AccountAlreadyExistsException(string name) 
        : base (CloverAceDomainErrorCodes.AccountAlreadyExists)
    { 
        WithData("name", name);
    }

    protected AccountAlreadyExistsException(SerializationInfo serializationInfo, StreamingContext context) 
        : base(serializationInfo, context)
    {
    }
}
