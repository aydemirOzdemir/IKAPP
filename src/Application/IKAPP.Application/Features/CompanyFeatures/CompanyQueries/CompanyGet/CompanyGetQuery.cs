using IKAPP.Application.Dtos.CompanyDTOs;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.CompanyFeatures.CompanyQueries.CompanyGet;

public class CompanyGetQuery:IRequest<IDataResult<CompanyViewDTO>>
{
    public string Id { get; set; }
}
