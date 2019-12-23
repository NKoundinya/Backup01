using AutoMapper;
using Entity.DataTransferObjects;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountOwner
{
    public class MappingClass : Profile
    {
        public MappingClass()
        {
            CreateMap<Owner, OwnerDto>();
            CreateMap<OwnerDto, Owner>();

            CreateMap<OwnerForUpdateDto, Owner>();
            CreateMap<Owner, OwnerForUpdateDto>();

            CreateMap<OwnerForCreationDto, Owner>();
            CreateMap<Owner, OwnerForCreationDto>();

            CreateMap<Account, AccountDto>();
            CreateMap<AccountDto, Account>();

            CreateMap<AccountForCreationDto, Account>();
            CreateMap<Account, AccountForCreationDto>();

            CreateMap<Account, AccountForUpdateDto>();
            CreateMap<AccountForUpdateDto, Account>();

        }
    }
}
