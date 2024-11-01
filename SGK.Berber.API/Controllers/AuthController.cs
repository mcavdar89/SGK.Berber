using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGK.Berber.BL.Abstracts;
using SGK.Berber.Model.Dtos;

namespace SGK.Berber.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthService _service;
        public AuthController(IAuthService service)
        {
            _service = service;
        }


        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody]LoginDto item)
        {
            var data = await _service.LoginAsync(item);
            if (data == null)
                return Unauthorized();
            return Ok(await _service.LoginAsync(item));
        }

    }
}
