using System;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Repository
{
    public abstract class ServiceManager : IServiceManager
    {
        public IActionResult BadRequest(object param)
        {
            return BadRequest(param);
        }

        public IActionResult BadRequest()
        {
            return BadRequest();
        }

        public IActionResult CreatedAtRoute(string str, object obj, object obj1)
        {
            return CreatedAtRoute(str, obj, obj1);
        }

        public Task ExecuteResultAsync(ActionContext context)
        {
            return ExecuteResultAsync(context);
        }

        public IActionResult Ok(object param)
        {
            return Ok(param);
        }

        public IActionResult Ok()
        {
            return Ok();
        }

        public IActionResult StatusCode(object status)
        {
            return StatusCode(status);
        }

        public IActionResult StatusCode()
        {
            return StatusCode();
        }
    }
}
