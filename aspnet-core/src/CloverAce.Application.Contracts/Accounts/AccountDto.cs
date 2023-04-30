using System;
using Volo.Abp.Application.Dtos;

namespace CloverAce.Accounts
{
    public class AccountDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
