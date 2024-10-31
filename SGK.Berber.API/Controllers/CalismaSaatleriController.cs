using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGK.Berber.BL.Abstracts;
using SGK.Berber.Model.Entities;

namespace SGK.Berber.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalismaSaatleriController : ControllerBase
    {
        ICalismaSaatleriService _servie;
        public CalismaSaatleriController(ICalismaSaatleriService service)
        {
            _servie = service;
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            var data = await _servie.GetByIdAsync(id);
            return Ok(data);


        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync([FromBody] CalismaSaatleri CalismaSaatleri)
        {
            var result = await _servie.AddAsync(CalismaSaatleri);
            return Ok(result);
        }
    }
}
