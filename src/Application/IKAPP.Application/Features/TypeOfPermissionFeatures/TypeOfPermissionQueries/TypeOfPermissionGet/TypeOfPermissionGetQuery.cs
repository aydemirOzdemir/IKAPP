using IKAPP.Application.Dtos.TypeOfPermissionDTOs;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.TypeOfPermissionFeatures.TypeOfPermissionQueries.TypeOfPermissionGet;

public class TypeOfPermissionGetQuery:IRequest<IDataResult<TypeOfPermissionViewDTO>>
{
    public string Id { get; set; }
}
