using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGK.Berber.Model.Dtos
{
    public class CalismaSaatleriDto
    {
        public int Id { get; set; }
        public string Saat { get; set; }
        public int Kontenjan { get; set; }
        public int SeciliSayisi { get; set; }
        public int KalanKontenjan { get => Kontenjan - SeciliSayisi; }
    }
}
