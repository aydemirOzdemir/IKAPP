using IKAPP.Domain.Entities.Enums;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.TypeOfPermissionFeatures.TypeOfPermissionCommands.TypeOfPermisisonCreate;

public class TypeOfPermissionCreateCommand:IRequest<IDataResult<TypeOfPermissionCreateCommand>>
{
    public string Name { get; set; }
    public byte Duration { get; set; }
    public Gender Gender { get; set; }
}
