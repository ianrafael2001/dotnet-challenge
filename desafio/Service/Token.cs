

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using desafio.Models;
using Microsoft.IdentityModel.Tokens;

namespace desafio.Service
{
    public static class TokenService
    {

        public static string generateToken(UserModel user){
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(Settings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,user.username.ToString()),
                    new Claim(ClaimTypes.Role,user.type.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature 
                ),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }

}