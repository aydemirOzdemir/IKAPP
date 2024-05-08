using IKAPP.Domain.Ultities.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.AutFeatures.SigIn;

public class SignInCommand:IRequest<IAuthDataResult<string,IdentityResult>>
{
    public string Email { get; set; } = default!;


    public string? Password { get; set; } = default!;


    public bool RememberMe { get; set; }
}
