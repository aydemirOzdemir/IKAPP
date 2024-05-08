using IKAPP.Application.Dtos.PersonalDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.PersonalFeatures.PersonalQueries.PersonalGetForEdit;

public class PersonalGetForEditQuery:IRequest<PersonalInformationForEditDTO>
{
    public string UserName { get; set; } = default!;
}
