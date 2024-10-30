using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGK.Berber.Model.Dtos;

namespace SGK.Berber.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandevuController : ControllerBase
    {
        public IActionResult Get()
        {
          

            return Ok();


        }
    }
}
