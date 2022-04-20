using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ODC_Courses.Helpers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ODC_Courses
{
    public class AuthService
    {
        public AuthService(IOptions<JWT>jwt)
        {
            _Jwt = jwt.Value;
        }

        public JWT _Jwt { get; }

        private JwtSecurityToken CreateJwtToken(string Username)
        {


            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("", Username),
            };

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _Jwt.Issure,
                audience: _Jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_Jwt.DurationInDays),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
    }
}
