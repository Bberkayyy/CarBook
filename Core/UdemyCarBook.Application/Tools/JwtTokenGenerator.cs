using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.DTOs;
using UdemyCarBook.Application.Features.Mediator.Results.AppUserResults;

namespace UdemyCarBook.Application.Tools;

public class JwtTokenGenerator
{
    public static TokenResponseDTO GenerateToken(GetCheckAppUserQueryResult result)
    {
        var claims = new List<Claim>();
        if (!string.IsNullOrWhiteSpace(result.UserRole))
            claims.Add(new Claim(ClaimTypes.Role, result.UserRole));
        claims.Add(new Claim(ClaimTypes.NameIdentifier, result.Id.ToString()));

        if (!string.IsNullOrWhiteSpace(result.UserName))
            claims.Add(new Claim("Username", result.UserName));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefault.Key));

        var signinCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var expireDate = DateTime.UtcNow.AddDays(JwtTokenDefault.ExpireTime);

        JwtSecurityToken token = new JwtSecurityToken(issuer: JwtTokenDefault.ValidIssuer, audience: JwtTokenDefault.ValidAudience, claims: claims, notBefore: DateTime.UtcNow,
            expires: expireDate, signingCredentials: signinCredentials);

        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        return new TokenResponseDTO(tokenHandler.WriteToken(token), expireDate);
    }
}
