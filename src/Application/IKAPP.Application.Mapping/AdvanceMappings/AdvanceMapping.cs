using AutoMapper;
using IKAPP.Application.Dtos.AdvanceDTOs;
using IKAPP.Application.Features.AdvanceFeatures.AdvanceCommands.AdvanceApproval;
using IKAPP.Application.Features.AdvanceFeatures.AdvanceCommands.AdvanceCreate;
using IKAPP.Application.Features.AdvanceFeatures.AdvanceCommands.AdvanceEdit;
using IKAPP.Domain.Entities.AggregateModels.Advances;
using IKAPP.Domain.Entities.AggregateModels.Advances.AdvanceDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Mapping.AdvanceMappings;

public class AdvanceMapping : Profile
{
    public AdvanceMapping()
    {
        CreateMap<AdvanceDTO, AdvanceViewDTO>().ReverseMap();
        CreateMap<AdvanceDTO, AdvanceCreateCommand>().ReverseMap();
        CreateMap<AdvanceUpdateDTO, AdvanceEditCommand>().ReverseMap();
        CreateMap<AdvanceUpdateViewDTO, AdvanceEditCommand>().ReverseMap();
        CreateMap<AdvanceViewDTO, AdvanceApprovalCommand>().ReverseMap();
        CreateMap<AdvanceDTO, AdvanceUpdateViewDTO>().ReverseMap();
    }
}
