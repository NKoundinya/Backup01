using Entity;
using Entity.Models;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    internal class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateAccount(Account account)
        {
            Create(account);
        }

        public Account GetAccountById(Guid id)
        {
            return FindByCondition(account => account.AccountId.Equals(id)).FirstOrDefault();
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return FindAll().OrderBy(Account => Account.AccountType).ToList();
        }

        public Account GetComplete(Guid id)
        {
            return FindByCondition(account => account.AccountId.Equals(id))
                .Include(account => account.Owner)
                .FirstOrDefault();
        }

        public IEnumerable<Owner> GetOwnersByAccountType(string accountType)
        {
            var accounts = FindByCondition(Account => Account.AccountType.Equals(accountType))
                .Include(account => account.Owner)
                .OrderBy(account => account.AccountType)
                .ToList();

            ICollection<Owner> owners = new List<Owner>();
            foreach(var account in accounts)
            {
                owners.Add(account.Owner);
            }

            return owners;
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
