using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DataTransferObjects
{
    public class AccountForCreationDto
    {
        public Guid AccountId { get; set; }
        public DateTime DateCreated { get; set; }
        public string AccountType { get; set; }
        public Guid OwnerId { get; set; }
    }
}
