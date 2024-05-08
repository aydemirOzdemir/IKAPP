using IKAPP.Domain.Ultities.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.VocationFeatures.VocationCommands.VocationEdit;
public class VocationEditCommand: IRequest<IDataResult<VocationEditCommand>>
{
    public string Id { get; set; }
    public string Name { get; set; }
}

