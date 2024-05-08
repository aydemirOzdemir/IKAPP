using IKAPP.Application.Dtos.RoleDTOs;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.RoleFeatures.RoleCommands.RoleAssign;

public class RoleAssignCommand:IRequest<IDataResult<IEnumerable<AssignRoleToUserViewDTO>>>
{
    public List<AssignRoleToUserViewDTO> Roles { get; set; }
    public string UserId { get; set; }
}
