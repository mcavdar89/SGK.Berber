using SGK.Berber.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGK.Berber.BL.Abstracts
{
    public interface ICalismaSaatleriService
    {
        Task<CalismaSaatleri> GetByIdAsync(int id);
        Task<string> AddAsync(CalismaSaatleri item);
    }
}
