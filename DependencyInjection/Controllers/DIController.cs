using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DIController : ControllerBase
    {
        private readonly INumGenerator2 numGenerator;
        private readonly INumGenerator numGenerator1;

        public DIController(INumGenerator2 numGenerator,INumGenerator numGenerator1)
        {
            this.numGenerator = numGenerator;
            this.numGenerator1 = numGenerator1;
        }
        [HttpGet]
        // This numbers came from NumGenerator instance (addScoped)
        public String Get()
        {
            int random1 = numGenerator1.RandomValue;
            int random2 = numGenerator.GetNumGeneratorRandomValue();
            return $"NumGenerator2.RandomValue: {random1} , NumGenerator.RandomValue: {random2}";
        }
    }
}