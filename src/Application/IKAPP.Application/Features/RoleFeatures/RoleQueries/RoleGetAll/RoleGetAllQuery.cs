using IKAPP.Application.Dtos.RoleDTOs;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.RoleFeatures.RoleQueries.RoleGetAll;

public class RoleGetAllQuery : IRequest<IDataResult<IEnumerable<RoleViewDTO>>>
{
    
}
