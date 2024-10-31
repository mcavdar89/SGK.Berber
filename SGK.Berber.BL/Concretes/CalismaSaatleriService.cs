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
    public class CalismaSaatleriService: ICalismaSaatleriService
    {
        private IBerberRepository _repository;
        public CalismaSaatleriService(IBerberRepository repository) 
        {         
            _repository = repository;
        }

        public async Task<CalismaSaatleri> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync<CalismaSaatleri>(id);
        }

        public async Task<string> AddAsync(CalismaSaatleri item)
        {
             _repository.Add(item);
            int count = await _repository.SaveAsync();
            return count > 0 ? "Randevu Eklendi" : "Randevu Eklenemedi";
        }


    }
}
