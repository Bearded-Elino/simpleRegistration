using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ValeRegistration.data;
using ValeRegistration.interfaces.accountInterface;
using ValeRegistration.mappers;
using ValeRegistration.models.account;

namespace ValeRegistration.repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _context;
        public AccountRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Account> CreateAccountAsync(Guid customerId)
        {
            try
            {
                int accountCount = await _context.Accounts.CountAsync(ac => ac.CustomerId == customerId);
                if (accountCount >= 1)
                {
                    throw new Exception("Customer cannot have more than one account");
                }
                var account = new Account
                {
                    CustomerId = customerId,
                    AccountNumber = GenerateAccountNumber()
                };
                _context.Accounts.Add(account);
                return account;
            }
            catch (System.Exception)
            {
                throw new Exception("An Error occured: Account not created");
            }
        }

        public string GenerateAccountNumber()
        {
            try
            {
                Random random = new Random();
                string letters = "1234567890";
                int length = 10;
                string accountNumber = "";

                for (int i = 0; i < length; i++)
                {
                    accountNumber += letters[random.Next(letters.Length)];
                }
                return accountNumber;
            }
            catch (System.Exception)
            {
                
                throw new Exception("could not generate account number");
            }
        }

        public async Task<List<Account>> GetAccounts()
        {
            try
            {
                var accounts = await _context.Accounts.ToListAsync();
                return accounts;
            }
            catch (System.Exception)
            {
                
                throw new Exception("could not retrieve accounts");
            }
        }
    }
}