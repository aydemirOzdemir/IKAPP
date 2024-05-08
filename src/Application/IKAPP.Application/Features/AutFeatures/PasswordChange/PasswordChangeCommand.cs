using IKAPP.Domain.Ultities.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.AutFeatures.PasswordChange;

public class PasswordChangeCommand:IRequest<IAuthResult<IdentityResult>>
{
    public string UserName { get; set; }
    public string PasswordOld { get; set; }


    public string PasswordNew { get; set; }

    public string PasswordConfirm { get; set; }
}
