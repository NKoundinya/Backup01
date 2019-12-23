using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    public interface IAccountRepository : IRepositoryBase<Account>
    {
        void CreateAccount(Account account);
        IEnumerable<Account> GetAllAccounts();
        Account GetAccountById(Guid id);
        Account GetComplete(Guid id);
        IEnumerable<Owner> GetOwnersByAccountType(string accountType);
        void UpdateAccount(Account account);
        void RemoveAccount(Account account);
    }
}
