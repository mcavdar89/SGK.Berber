using AutoMapper;
using SGK.Berber.Model.Dtos;
using SGK.Berber.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGK.Berber.Model.Profiles
{
    public class BerberProfile : Profile
    {
        public BerberProfile()
        {
            CreateMap<Randevu, RandevuDto>()
              .ForMember(des => des.PersonelAd,src=>src.MapFrom(c=>c.Personel.Ad))
              .ForMember(des => des.PersonelSoyad, src=>src.MapFrom(c=>c.Personel.Soyad))
              .ForMember(des => des.Saat, src=>src.MapFrom(c=>c.CalismaSaatleri.Saat))
                ;
        }
    }
}
