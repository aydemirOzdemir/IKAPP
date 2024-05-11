using IKAPP.Application.Dtos.AdvanceDTOs;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.AdvanceFeatures.AdvanceQueries.AdvanceGetForEdit;

public class AdvanceGetForEditQuery:IRequest<IDataResult<AdvanceUpdateViewDTO>>
{
    public string Id { get; set; }

    public bool IsTracking { get; set; } = true;
}
