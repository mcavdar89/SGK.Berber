using AutoMapper;
using Infrastructure.DAL.Concretes;
using SGK.Berber.DAL.Abstracts;
using SGK.Berber.DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGK.Berber.DAL.Concretes
{
    public class BerberRepository : BaseRepository, IBerberRepository
    {
        //private BerberDbContext _dbContext;
        //private IMapper _mapper;
        public BerberRepository(BerberDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {

        }
    }
}
