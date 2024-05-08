using IKAPP.Application.Dtos.DepartmentDTOs;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.DepartmentFeatures.DepartmentQueries.DepartmentGetAll;

public class DepartmentGetAllQuery : IRequest<IDataResult<IEnumerable<DepartmentViewDTO>>>
{
    public bool Tracking { get; set; } = true;
}
