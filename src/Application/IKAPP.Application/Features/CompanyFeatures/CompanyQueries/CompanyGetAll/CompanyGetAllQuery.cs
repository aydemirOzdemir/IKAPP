using IKAPP.Application.Dtos.CompanyDTOs;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.CompanyFeatures.CompanyQueries.CompanyGetAll;

public class CompanyGetAllQuery:IRequest<IDataResult<CompanyViewDTO>>
{
    public bool Tracking { get; set; } = true;
}
