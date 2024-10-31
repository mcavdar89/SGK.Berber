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
    public class RandevuService : IRandevuService
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


        public async Task<string> AddRandevuAsync(Randevu randevu)
        {
            _repository.Add(randevu);
            int count = await _repository.SaveAsync();
            return count > 0 ? "Randevu Eklendi" : "Randevu Eklenemedi";
        }

        public async Task<List<Randevu>> ListAsync(int? calismaSaatId = null)
        {
            if(calismaSaatId == null)
            {
                return await _repository.ListAsync<Randevu>();
            }

            return await _repository.ListAsync<Randevu>(d=>d.CalismaSaatId == calismaSaatId);
        }
    }
}
