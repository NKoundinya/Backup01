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
    class OwnerRepository: RepositoryBase<Owner>, IOwnerRepository
    {
        public OwnerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateOwner(Owner owner)
        {
            Create(owner);
        }

        public IEnumerable<Owner> GetAllOwners()
        {
            return FindAll()
                .OrderBy(owner => owner.Name)
                .ToList();
        }

        public Owner GetComplete(Guid id)
        {
            return FindByCondition(owner => owner.OwnerId.Equals(id))
                .Include(owner => owner.Accounts)
                .FirstOrDefault();
        }

        public IEnumerable<Account> GetAccountsOfOwner(Guid id)
        {
            return FindByCondition(owner => owner.OwnerId.Equals(id))
                .Include(owner => owner.Accounts)
                .FirstOrDefault().Accounts;
        }

        public Owner GetOwnerById(Guid id)
        {
            return FindByCondition(owner => owner.OwnerId.Equals(id))
                .FirstOrDefault();
        }

        public void UpdateOwner(Owner owner)
        {
            Update(owner);
        }

        public void RemoveOwner(Owner owner)
        {
            Delete(owner);
        }
    }
}
