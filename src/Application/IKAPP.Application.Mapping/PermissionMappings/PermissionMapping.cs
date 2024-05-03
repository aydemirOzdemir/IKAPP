using AutoMapper;
using IKAPP.Application.Dtos.PermissionDTOs;
using IKAPP.Application.Features.PermissionFeatures.PermissionCommands.PermissionApproval;
using IKAPP.Application.Features.PermissionFeatures.PermissionCommands.PermissionCreate;
using IKAPP.Application.Features.PermissionFeatures.PermissionCommands.PermissionEdit;
using IKAPP.Domain.Entities.AggregateModels.Permissions;
using IKAPP.Domain.Entities.AggregateModels.Permissions.PermissionDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Mapping.PermissionMappings;

public class PermissionMapping : Profile
{
    public PermissionMapping()
    {
        CreateMap<PermissionDTO, PermissionViewDTO>().ReverseMap();
        CreateMap<PermissionDTO, PermissionCreateCommand>().ReverseMap();
        CreateMap<PermissionDTO, PermissionEditCommand>().ReverseMap();
        CreateMap<PermissionUpdateViewDTO, PermissionEditCommand>().ReverseMap();
        CreateMap<PermissionViewDTO, PermissionApprovalCommand>().ReverseMap();
        CreateMap<PermissionDTO, PermissionUpdateViewDTO>().ReverseMap();
    }
}
