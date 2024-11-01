using SGK.Berber.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGK.Berber.BL.Abstracts
{
    public interface IAuthService
    {
        Task<string> LoginAsync(LoginDto item);
    }
}
