using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface IAccountRepository : IRepositoryBase<Account>
    {
        IEnumerable<Account> GetAllAccounts();
        Account GetAccountById(Guid accountId);
        IEnumerable<Account> GetAccountWithDetails(Guid accountId);
        void CreateAccount(Account account);
        void UpdateAccount(Account account);
        void RemoveAccount(Account account);
    }
}