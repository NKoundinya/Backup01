﻿using Entity;
using Entity.Models;
using Interfaces;
using System;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repositoryContext;
        private IOwnerRepository _owner;
        private IAccountRepository _account;
        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public IOwnerRepository Owner
        {
            get
            { 
                if(_owner == null)
                {
                    _owner = new OwnerRepository(_repositoryContext);
                }
                return _owner;
            }
        }

        public IAccountRepository Account
        {
            get
            {
                if(_account == null)
                {
                    _account = new AccountRepository(_repositoryContext);
                }
                return _account;
            }
        }

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}
