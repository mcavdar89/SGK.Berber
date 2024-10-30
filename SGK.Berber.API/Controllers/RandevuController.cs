using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using SGK.Berber.BL.Abstracts;
using SGK.Berber.Model.Dtos;

namespace SGK.Berber.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandevuController : ControllerBase
    {
        IRandevuService _servie;
        public RandevuController(IRandevuService service)
        {
            _servie = service;
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetAsync([FromRoute]int id)
        {
           var data = await _servie.GetRandevuByIdAsync(id);
            return Ok(data);


        }
    }
}
