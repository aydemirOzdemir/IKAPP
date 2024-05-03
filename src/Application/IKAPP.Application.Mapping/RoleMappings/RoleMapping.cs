using AutoMapper;
using IKAPP.Application.Dtos.RoleDTOs;
using IKAPP.Application.Features.RoleFeatures.RoleCommands.RoleCreate;
using IKAPP.Application.Features.RoleFeatures.RoleCommands.RoleEdit;
using IKAPP.Domain.Entities.AggregateModels.Roles;
using IKAPP.Domain.Entities.AggregateModels.Roles.RoleDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Mapping.RoleMappings;

public class RoleMapping : Profile
{
    public RoleMapping()
    {
        CreateMap<RoleDTO, RoleCreateCommand>().ReverseMap();
        CreateMap<RoleDTO, RoleViewDTO>().ReverseMap();
        CreateMap<RoleDTO, UpdateRoleViewDTO>().ReverseMap();
        CreateMap<RoleEditCommand, UpdateRoleViewDTO>().ReverseMap();
        CreateMap<RoleDTO, AssignRoleToUserViewDTO>().ReverseMap();

    }
}
