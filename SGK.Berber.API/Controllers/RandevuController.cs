using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using SGK.Berber.BL.Abstracts;
using SGK.Berber.Model.Dtos;
using SGK.Berber.Model.Entities;

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
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            var data = await _servie.GetRandevuByIdAsync(id);
            return Ok(data);


        }

        //a == b ? c:d;
        // a ?? b??c??d....

        [HttpGet("list/{calismaSaatId?}")]
        public async Task<IActionResult> ListAsync([FromRoute] int? calismaSaatId = null)
        {
            var data = await _servie.ListAsync(calismaSaatId);
            return Ok(data);


        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync([FromBody] Randevu randevu)
        {
            var result = await _servie.AddRandevuAsync(randevu);
            return Ok(result);
        }





    }
}
