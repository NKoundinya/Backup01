using Entities.Models;
using System;

namespace Entities.DataTransferObjects
{
    public class AccountDto
    {
        public Guid AccountId { get; set; }
        public DateTime DateCreated { get; set; }
        public string AccountType { get; set; }
        public Owner Owner { get; set; }

    }
}