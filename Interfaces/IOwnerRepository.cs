using Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IOwnerRepository : IRepositoryBase<Owner>
    {
        void CreateOwner(Owner owner);
        IEnumerable<Owner> GetAllOwners();
        Owner GetOwnerById(Guid id);
        Owner GetComplete(Guid id);
        IEnumerable<Account> GetAccountsOfOwner(Guid id);
        void UpdateOwner(Owner owner);
        void RemoveOwner(Owner owner);
    }
}
