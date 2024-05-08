using IKAPP.Application.Dtos.AdvanceDTOs;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.AdvanceFeatures.AdvanceQueries.AdvanceGet;

public class AdvanceGetQuery:IRequest<IDataResult<AdvanceViewDTO>>
{
    public bool Tracking { get; set; } = true;

    public bool IsApproval { get; set; } = false;
}

