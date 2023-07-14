using JWTAuthenticationManager.Models;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JwtRegisteredClaimNames = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;

namespace JWTAuthenticationManager
{
    public class JwtTokenHandler
    {
        public const string JWT_Secret_Key = "G-KaPdSgVkYp3s6v9y/B?E(H+MbQeThWmZq4t7w!z%C&F)J@NcRfUjXn2r5u8x/A";
        private const int JWT_Token_Validity_Min = 20;

        public JwtTokenHandler()
        {

        }
        public AuthenticationResponse GenerateToken(AuthenticationRequest request, string role)
        {


            //start working on jwt token
            var tokenExpiryTime = DateTime.UtcNow.AddMinutes(JWT_Token_Validity_Min);
            var tokenKey = Encoding.ASCII.GetBytes(JWT_Secret_Key);
            var claimsIdentity = new ClaimsIdentity(new List<Claim> {
             new Claim(JwtRegisteredClaimNames.Name,request.Username),
             new Claim(ClaimTypes.Role,role)
            });

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature
                );

            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = tokenExpiryTime,
                SigningCredentials = signingCredentials

            };
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);
            return new AuthenticationResponse { Token = token, ExpiresIn = (int)tokenExpiryTime.Subtract(DateTime.Now).TotalSeconds, Username = request.Username };
        }
    }
}
