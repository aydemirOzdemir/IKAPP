using IKAPP.Application.Dtos.PermissionDTOs;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.PermissionFeatures.PermissionQueries.PermissionGet;

public class PermissionGetQuery:IRequest<IDataResult<PermissionViewDTO>>
{
    public string Id { get; set; }

    public bool IsApproval { get; set; } = false;
}
