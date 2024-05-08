using IKAPP.Application.Dtos.TypeOfPermissionDTOs;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.TypeOfPermissionFeatures.TypeOfPermissionQueries.TypeOfPermissionGetAll;

public class TypeOfPermissionGetAllQuery:IRequest<IDataResult<IEnumerable<TypeOfPermissionViewDTO>>>
{
    public bool Tracking { get; set; } = true;
    public string UserName { get; set; }
}
