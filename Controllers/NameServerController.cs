using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OpenRec2.Controllers
{
    [Route("/")]
    [ApiController]
    public class NameServerController : ControllerBase
    {
        [HttpGet]
        public IActionResult NS([FromQuery] string? v)
        {
            if (v == "1" || string.IsNullOrEmpty(v))
            {
                return Ok(new
                {
                    API = "http://localhost:"
                });
            }

            return Ok();
        }
    }
}
