using IKAPP.Application.Dtos.PermissionDTOs;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.PermissionFeatures.PermissionQueries.PermissionGetAll;

public class PermissionGetAllQuery:IRequest<IDataResult<IEnumerable<PermissionViewDTO>>>
{
    public string UserName { get; set; }
    public bool Tracking { get; set; } = true;
    public bool IsApproval { get; set; } = false;
}
