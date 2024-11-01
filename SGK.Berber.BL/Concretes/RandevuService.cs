using AutoMapper;
using SGK.Berber.BL.Abstracts;
using SGK.Berber.DAL.Abstracts;
using SGK.Berber.Model.Dtos;
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
        private IMapper _mapper;
        public RandevuService(IBerberRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Randevu> GetRandevuByIdAsync(int id)
        {
            return await _repository.GetByIdAsync<Randevu>(id);
        }


        public async Task<string> AddRandevuAsync(RandevuDto data)
        {
            var entity = _mapper.Map<Randevu>(data);
            _repository.Add(entity);
            int count = await _repository.SaveAsync();
            return count > 0 ? "Randevu Eklendi" : "Randevu Eklenemedi";
        }

        public async Task<List<RandevuDto>> ListAsync(int? calismaSaatId = null)
        {
            if (calismaSaatId == null)
            {
                return await _repository.ListProjectAsync<Randevu, RandevuDto>();
            }

            return await _repository.ListProjectAsync<Randevu, RandevuDto>(d => d.CalismaSaatId == calismaSaatId);
        }
    }
}
