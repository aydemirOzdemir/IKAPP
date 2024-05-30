using IKAPP.Domain.Entities.AggregateModels.Personals;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Contract.Tokens;

public interface ITokenService
{
    Task<JwtSecurityToken> CreateToken(Personal user, IList<string> roles);
    string GenerateRefreshToken();
    ClaimsPrincipal? GetPrincipalFromExpireToken(string? token);
}
