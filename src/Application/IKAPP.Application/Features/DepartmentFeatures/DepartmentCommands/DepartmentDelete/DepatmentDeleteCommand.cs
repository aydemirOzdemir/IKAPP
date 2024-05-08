using IKAPP.Domain.Ultities.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.DepartmentFeatures.DepartmentCommands.DepartmentDelete;

public class DepatmentDeleteCommand:IRequest<IResult>
{
    public string Id { get; set; } = default!;
}
