using IKAPP.Application.Dtos.PermissionDTOs;
using IKAPP.Domain.Entities.Enums;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.PermissionFeatures.PermissionCommands.PermissionApproval;

public class PermissionApprovalCommand:IRequest<IDataResult<PermissionViewDTO>>
{
    public string Id { get; set; }
    public Approval StatusofApproval { get; set; }
}
