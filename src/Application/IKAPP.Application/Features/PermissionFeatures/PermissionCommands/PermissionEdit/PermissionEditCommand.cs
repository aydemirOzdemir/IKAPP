using IKAPP.Domain.Ultities.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.PermissionFeatures.PermissionCommands.PermissionEdit;

public class PermissionEditCommand:IRequest<IResult>
{
    public string Id { get; set; }

    public DateTime StartedDate { get; set; }

    public string TypeofPermissionId { get; set; }
}
