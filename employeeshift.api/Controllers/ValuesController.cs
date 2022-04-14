using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace employeeshift.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Test()
        {
            return Ok();
        }
    }
}
