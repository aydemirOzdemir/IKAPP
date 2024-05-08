using IKAPP.Application.Dtos.RoleDTOs;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.RoleFeatures.RoleQueries.RoleGetAllForAssign;

public class RoleGetForAssignQuery: IRequest<IDataResult<List<AssignRoleToUserViewDTO>>>
{
    public string UserId { get; set; }
}
