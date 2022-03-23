using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        // only  authorized user can access
        [HttpGet]
        [Route("purchases")]
        public async Task<IActionResult> Purchases()
        {
            return Ok();
        }

    }
}
