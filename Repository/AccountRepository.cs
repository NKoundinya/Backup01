using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateAccount(Account account)
        {
            Create(account);
        }

        public Account GetAccountById(Guid accountId)
        {
            return FindByCondition(account => account.AccountId.Equals(accountId))
                .FirstOrDefault();
        }

        public IEnumerable<Account> GetAccountWithDetails(Guid accountId)
        {
            return FindAll()
                .OrderBy(account => account.AccountType)
                .Include(owner => owner.OwnerId)
                .ToList();
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return FindAll()
                .OrderBy(account => account.AccountType)
                .ToList();
        }

        public void RemoveAccount(Account account)
        {
            Delete(account);
        }

        public void UpdateAccount(Account account)
        {
            Update(account);
        }
    }
}