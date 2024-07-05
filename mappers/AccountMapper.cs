using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValeRegistration.dtos;
using ValeRegistration.models.account;

namespace ValeRegistration.mappers
{
    public static class AccountMapper
    {
        public static AccountDto ToAccountDto(this Account account)
        {
            return new AccountDto
            {
                Id = account.Id,
                CustomerId = account.CustomerId,
                AccountNumber = account.AccountNumber,
                Balance  = account.Balance,
            };
        }

        public static AccountDto ToAccountModel(this AccountDto accountDto)
        {
            return new AccountDto
            {
                Id = accountDto.Id,
                CustomerId = accountDto.CustomerId,
                AccountNumber = accountDto.AccountNumber,
                Balance  = accountDto.Balance,
            };
        }
    }
}