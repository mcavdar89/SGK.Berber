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
            CalismaSaatleriDto calismaSaatleriDto = new CalismaSaatleriDto
            {
                Id = 1,
                Saat = "09:00",
                Kontenjan = 10,
                SeciliSayisi = 5
            };

            return Ok(calismaSaatleriDto);


        }
    }
}
