﻿using IKAPP.Application.Dtos.DepartmentDTOs;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.DepartmentFeatures.DepartmentQueries.DepartmentGet;

public class DepartmentGetQuery:IRequest<IDataResult<DepartmentViewDTO>>
{
    public string Id { get; set; } = default!;
}
