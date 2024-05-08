﻿using IKAPP.Domain.Ultities.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.VocationFeatures.VocationCommands.VocationDelete;

public class VocationDeleteCommand:IRequest<IResult>
{
    public string Id { get; set; }
}
