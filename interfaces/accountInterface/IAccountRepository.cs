using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValeRegistration.models.account;

namespace ValeRegistration.interfaces.accountInterface
{
    public interface IAccountRepository
    {
        public string GenerateAccountNumber();
        public Task<Account> CreateAccountAsync(Guid customerId);
        public Task<List<Account>> GetAccounts();
    }
}