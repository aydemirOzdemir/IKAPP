using AutoMapper;
using IKAPP.Application.Dtos.TypeOfPermissionDTOs;
using IKAPP.Application.Features.TypeOfPermissionFeatures.TypeOfPermissionCommands.TypeOfPermisisonCreate;
using IKAPP.Application.Features.TypeOfPermissionFeatures.TypeOfPermissionCommands.TypeOfPermissionEdit;
using IKAPP.Domain.Entities.AggregateModels.TypeofPermissions;
using IKAPP.Domain.Entities.AggregateModels.TypeofPermissions.TypeofPermissionDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Mapping.TypeOfPermissionMappings;

public class TypeOfPermissionMapping : Profile
{
    public TypeOfPermissionMapping()
    {
        CreateMap<TypeOfPermissionDTO, TypeOfPermissionViewDTO>().ReverseMap();
        CreateMap<TypeOfPermissionDTO, TypeOfPermissionCreateCommand>().ReverseMap();
        CreateMap<TypeOfPermissionDTO, TypeOfPermissionEditCommand>().ReverseMap();
        CreateMap<TypeOfPermissionViewDTO, TypeOfPermissionEditCommand>().ReverseMap();
    }
}
