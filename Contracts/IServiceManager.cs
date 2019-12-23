using Microsoft.AspNetCore.Mvc;

namespace Contracts
{
    public interface IServiceManager : IActionResult
    {
        IActionResult Ok(object param);
        IActionResult Ok();
        IActionResult StatusCode(object param);
        IActionResult StatusCode();
        IActionResult BadRequest(object param);
        IActionResult BadRequest();
        IActionResult CreatedAtRoute(string str, object obj, object obj1);
    }
}
