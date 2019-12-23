using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public interface IFile : IFormFile
    {
        string name { get; set; }
    }
}
