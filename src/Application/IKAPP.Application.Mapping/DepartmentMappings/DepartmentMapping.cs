using AutoMapper;
using IKAPP.Application.Dtos.DepartmentDTOs;
using IKAPP.Application.Features.DepartmentFeatures.DepartmentCommands.DepartmentCreate;
using IKAPP.Application.Features.DepartmentFeatures.DepartmentCommands.DepartmentEdit;
using IKAPP.Domain.Entities.AggregateModels.Departments;
using IKAPP.Domain.Entities.AggregateModels.Departments.DepartmentDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Mapping.DepartmentMappings;

public class DepartmentMapping:Profile
{
    public DepartmentMapping()
    {
        CreateMap<DepartmentDTO, DepartmentCreateCommand>().ReverseMap();
        CreateMap<DepartmentDTO, DepartmentEditCommand>().ReverseMap();
        CreateMap<DepartmentDTO, DepartmentViewDTO>().ReverseMap();
        CreateMap<DepartmentEditCommand, DepartmentViewDTO>().ReverseMap();

    }
}
