using IKAPP.Application.Dtos.PermissionDTOs;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.PermissionFeatures.PermissionQueries.PermissionGetForEdit;

public class PermissionGetForEditCommand:IRequest<IDataResult<PermissionUpdateViewDTO>>
{
    public string Id { get; set; }

    public bool IsTracking { get; set; } = true;
}
