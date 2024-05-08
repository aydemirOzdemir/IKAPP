using IKAPP.Application.Dtos.PersonalDTOs;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.PersonalFeatures.PersonalQueries.PersonalGetAll;

public class PersonalGetAllQuery:IRequest<IDataResult<IEnumerable<PersonalViewDTO>>>
{
    public string UserName { get; set; }
    public string? CompanyId { get; set; }
}
