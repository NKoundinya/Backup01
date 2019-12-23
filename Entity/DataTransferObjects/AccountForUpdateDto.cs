using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DataTransferObjects
{
    public class AccountForUpdateDto
    {
        public DateTime DateCreated { get; set; }
        public string AccountType { get; set; }
        public Guid OwnerId { get; set; }
    }
}
