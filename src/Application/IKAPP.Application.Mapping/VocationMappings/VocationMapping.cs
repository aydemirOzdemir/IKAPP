using AutoMapper;
using IKAPP.Application.Dtos.VocationDTOs;
using IKAPP.Application.Features.VocationFeatures.VocationCommands.VocationCreate;
using IKAPP.Application.Features.VocationFeatures.VocationCommands.VocationEdit;
using IKAPP.Domain.Entities.AggregateModels.Vocations;
using IKAPP.Domain.Entities.AggregateModels.Vocations.VocationDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Mapping.VocationMappings;

public class VocationMapping : Profile
{
    public VocationMapping()
    {
        CreateMap<VocationDTO, VocationCreateCommand>().ReverseMap();
        CreateMap<VocationDTO, VocationEditCommand>().ReverseMap();
        CreateMap<VocationDTO, VocationViewDTO>().ReverseMap();
        CreateMap<VocationEditCommand, VocationViewDTO>().ReverseMap();
    }

}