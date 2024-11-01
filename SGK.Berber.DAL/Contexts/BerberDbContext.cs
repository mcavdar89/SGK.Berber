using Microsoft.EntityFrameworkCore;
using SGK.Berber.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGK.Berber.DAL.Contexts
{
    public class BerberDbContext : DbContext
    {
        public BerberDbContext(DbContextOptions<BerberDbContext> options) : base(options)
        {
        }

        DbSet<CalismaSaatleri> CalismaSaatleri { get; set; }
        DbSet<Personel> Personel { get; set; }
        DbSet<Randevu> Randevu { get; set; }
        DbSet<Kullanici> Kullanici { get; set; }
        //DENEME


    }
}
