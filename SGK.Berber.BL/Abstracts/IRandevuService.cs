using SGK.Berber.Model.Dtos;
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
        Task<string> AddRandevuAsync(RandevuDto data);

        Task<List<RandevuDto>> ListAsync(int? calismaSaatId = null);
    }
}
