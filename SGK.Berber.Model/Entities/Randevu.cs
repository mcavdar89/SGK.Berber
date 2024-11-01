using Infrastructure.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGK.Berber.Model.Entities
{
    public class Randevu : BaseEntity
    {
        public int Id { get; set; }
        public int StatusId { get; set; }

        public int? PersonelId { get; set; }
        public int CalismaSaatId { get; set; }
        public DateTime Tarih { get; set; }

        [ForeignKey("PersonelId")]
        public virtual Personel? Personel {get;set;}

        [ForeignKey("CalismaSaatId")]
        public virtual CalismaSaatleri CalismaSaatleri {get;set; }
    }
}
