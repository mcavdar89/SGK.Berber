using Infrastructure.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGK.Berber.Model.Entities
{
    public class CalismaSaatleri:BaseEntity
    {
        public int Id { get; set; }
        public string Saat { get; set; }
        public int Kontenjan { get; set; }
    }
}
