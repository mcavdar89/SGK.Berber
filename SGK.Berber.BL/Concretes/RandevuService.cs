using SGK.Berber.BL.Abstracts;
using SGK.Berber.DAL.Abstracts;
using SGK.Berber.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGK.Berber.BL.Concretes
{
    public class RandevuService:IRandevuService
    {
        private IBerberRepository _repository;
        public RandevuService(IBerberRepository repository) 
        {         
            _repository = repository;
        }

        public async Task<Randevu> GetRandevuByIdAsync(int id)
        {
            return await _repository.GetByIdAsync<Randevu>(id);
        }



    }
}
