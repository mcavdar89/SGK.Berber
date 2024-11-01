using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SGK.Berber.BL.Abstracts;
using SGK.Berber.DAL.Abstracts;
using SGK.Berber.Model.Dtos;
using SGK.Berber.Model.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SGK.Berber.BL.Concretes
{
    public class AuthService : IAuthService
    {
        IConfiguration _configuration;
        IBerberRepository _repository;

        public AuthService(IConfiguration configuration,IBerberRepository repository)
        {
            _configuration = configuration;
            _repository = repository;

        }

        public async Task<string> LoginAsync(LoginDto item)
        {
            //LDAP kontrolü yapılacak
            /*
              public static bool ValidateCredentials(string userName, string password)
        {
            string AdPath = _configuration.GetSection("AppSettings")["ADPath"];
            string AdNode = _configuration.GetSection("AppSettings")["ADNode"];


            using (var principalContext = new PrincipalContext(ContextType.Domain, AdPath, AdNode))
            {
                return principalContext.ValidateCredentials(userName, password);
            }
        }
             */
            if (!(item.UserName == "mcavdar" && item.Password == "1"))
            {
                return null;
            }

           var user = await _repository.GetProjectAsync<Kullanici, UserDto>(d => d.UserName == item.UserName);

            var token = CreateToken(user);

            return token;

        }


        private string CreateToken(UserDto user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecurityKey"]));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var timeLife = DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JWT:TokenTimeLife"]));


            //List<Claim> claims =new ();
            var claims =new List<Claim>();
            claims.Add(new Claim("id", user.Id.ToString()));
            claims.Add(new Claim("username", user.UserName));
            claims.Add(new Claim("ad", user.Ad));
            claims.Add(new Claim("soyad", user.Soyad));

            foreach (var item in user.Role.Split(","))
            {
                claims.Add(new Claim(ClaimTypes.Role, item));
            }



           




            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                expires: timeLife,
                signingCredentials: credentials,
                claims: claims
                );


            return new JwtSecurityTokenHandler().WriteToken(token);

        }


    }
}
