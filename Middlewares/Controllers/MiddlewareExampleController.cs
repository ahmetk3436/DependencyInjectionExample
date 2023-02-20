using Microsoft.AspNetCore.Mvc;

namespace Middlewares.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MiddlewareExampleController : ControllerBase
    {
       
        [HttpGet]
        public String Get()
        {
            return "OK";
        }
    }
}