using IKAPP.Application.Dtos.VocationDTOs;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.VocationFeatures.VocationQueries.VocationGetAll;

public class VocationGetAllQuery:IRequest<IDataResult<IEnumerable<VocationViewDTO>>>
{
    public bool Tracking { get; set; } = true;
}
