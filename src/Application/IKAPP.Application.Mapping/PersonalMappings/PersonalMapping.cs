using AutoMapper;
using IKAPP.Application.Dtos.PersonalDTOs;
using IKAPP.Application.Features.AutFeatures.PasswordChange;
using IKAPP.Application.Features.PersonalFeatures.PersonalCommands.PersonalCreate;
using IKAPP.Application.Features.PersonalFeatures.PersonalCommands.PersonalEdit;
using IKAPP.Domain.Entities.AggregateModels.Personals;
using IKAPP.Domain.Entities.AggregateModels.Personals.PersonalDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IKAPP.Application.Mapping.PersonalMappings;

public class PersonalMapping:Profile
{
    public PersonalMapping()
    {
        CreateMap<PersonalInformationViewDTO, PersonalDTO>().ReverseMap();
        CreateMap<PersonalInformationForEditDTO, PersonalEditCommand>().ReverseMap();
        CreateMap<PersonalEditCommand, PersonalDTO>().ReverseMap();
        CreateMap<PersonalCreateCommand, PersonalDTO>().ReverseMap();
        CreateMap<PasswordChangeCommand, PersonalDTO>().ReverseMap();
        CreateMap<PersonalViewDTO, PersonalDTO>().ReverseMap();
        CreateMap<PersonalDTO, PersonalInformationForEditDTO>().ReverseMap();
        CreateMap<PersonalDTO, PersonalDetailViewDTO>().ReverseMap();
    }
}
