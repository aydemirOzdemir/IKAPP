using IKAPP.Domain.Ultities.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.RoleFeatures.RoleCommands.RoleCreate;

public class RoleCreateCommand:IRequest<IAuthResult<IdentityResult>>
{
    public string Name { get; set; }
}
