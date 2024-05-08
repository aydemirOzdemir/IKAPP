using IKAPP.Application.Dtos.PersonalDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.PersonalFeatures.PersonalQueries.PersonalGetByName;

public class PersonalGetByNameQuery:IRequest<PersonalInformationViewDTO>
{
    public string UserName { get; set; }
}
