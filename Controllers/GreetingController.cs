using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreetingController : ControllerBase
    {
        //[HttpGet]
        //public IActionResult SayHello()
        //{
        //    return Ok("Hellofrom my first Web API!");
        //}
        [HttpGet]
        public IActionResult SayHello()
        {
            return Ok("Hello, World!");
        }

    }
}
