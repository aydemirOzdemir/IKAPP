using IKAPP.Application.Dtos.VocationDTOs;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.VocationFeatures.VocationQueries.VocationGet;

public class VocationGetQuery : IRequest<IDataResult<VocationViewDTO>>
{
    public string Id { get; set; } = default!;
}
