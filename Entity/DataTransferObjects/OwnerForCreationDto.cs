﻿using Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DataTransferObjects
{
    public class OwnerForCreationDto
    {
        public Guid OwnerId { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}
