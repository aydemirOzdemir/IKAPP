using IKAPP.Domain.Entities.Enums;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.TypeOfPermissionFeatures.TypeOfPermissionCommands.TypeOfPermissionEdit;

public class TypeOfPermissionEditCommand:IRequest<IResult>
{
    public string Id { get; set; }
    public string Name { get; set; } = default!;
    public byte Duration { get; set; }
    public Gender Gender { get; set; }
}
