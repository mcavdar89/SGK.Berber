using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGK.Berber.Model.Dtos
{
    public class RandevuDto
    {
        public int Id { get; set; }
        public int PersonelId { get; set; }
        public string PersonelAd { get; set; }
        public string PersonelSoyad { get; set; }

        public int CalismaSaatId { get; set; }
        public string Saat { get; set; }
        public DateTime Tarih { get; set; }


    }
}
