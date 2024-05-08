using IKAPP.Application.Dtos.RoleDTOs;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.RoleFeatures.RoleQueries.RoleGet;

public class RoleGetQuery:IRequest<IDataResult<UpdateRoleViewDTO>>
{
    public string Id { get; set; }
}

