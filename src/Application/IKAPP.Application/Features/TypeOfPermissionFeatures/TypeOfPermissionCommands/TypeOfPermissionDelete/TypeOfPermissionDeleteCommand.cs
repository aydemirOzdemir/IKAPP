using IKAPP.Domain.Ultities.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.TypeOfPermissionFeatures.TypeOfPermissionCommands.TypeOfPermissionDelete;

public class TypeOfPermissionDeleteCommand:IRequest<IResult>
{
    public string Id { get; set; }
}
