using SGK.Berber.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGK.Berber.BL.Abstracts
{
    public interface IRandevuService
    {
        Task<Randevu> GetRandevuByIdAsync(int id);
        Task<string> AddRandevuAsync(Randevu randevu);

        Task<List<Randevu>> ListAsync(int? calismaSaatId = null);
    }
}
