using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGK.Berber.BL.Abstracts;

namespace SGK.Berber.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="admin")]
    public class PersonelController : ControllerBase
    {
        IPersonelService _service;
        public PersonelController(IPersonelService service)
        {
            _service = service;
        }
        
        [HttpGet("list")]
        public async Task<IActionResult> ListAsync()
        {
            var data = await _service.ListAsync();
            return Ok(data);
        }


    }
}
