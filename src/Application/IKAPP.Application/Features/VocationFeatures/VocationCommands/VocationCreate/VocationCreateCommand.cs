using IKAPP.Domain.Ultities.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.VocationFeatures.VocationCommands.VocationCreate;

public class VocationCreateCommand:IRequest<IResult>
{
    public string Name { get; set; }
}
