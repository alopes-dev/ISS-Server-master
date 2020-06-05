using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ISS.GraphQL.Identity
{
    public static class IdentityExtentions
    {
        public static string GenerateToken(this IdentityUser usuario, IConfiguration configuration)
        {
            var claims = new[]
            {
                // Jwt token identifyer
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString("N")),

                //O nome de usuário padrão
                new Claim(ClaimsIdentity.DefaultNameClaimType,usuario.UserName),

                new Claim(ClaimTypes.NameIdentifier,usuario.Id)
            };
            // Credenciais usados para gerar um token
            var credenciais = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Audience"],
                audience: configuration["Jwt:Issuer"],
                claims: claims,
                signingCredentials: credenciais,
                expires: DateTime.Now.AddSeconds(120));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
