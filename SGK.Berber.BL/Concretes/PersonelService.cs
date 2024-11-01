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
    public class PersonelService:IPersonelService
    {
        private readonly IBerberRepository _repository;

        public PersonelService(IBerberRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<PersonelDto>> ListAsync()
        {
            var list = await _repository.ListProjectAsync<Personel, PersonelDto>();

            return list;


        }


    }
}
