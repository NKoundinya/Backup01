using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DataTransferObjects
{
    public class OwnerForUpdateDto
    {
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }
    }
}
