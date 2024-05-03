using AutoMapper;
using IKAPP.Application.Dtos.CompanyDTOs;
using IKAPP.Application.Features.CompanyFeatures.CompanyCommands.CompanyCreate;
using IKAPP.Application.Features.CompanyFeatures.CompanyCommands.CompanyEdit;
using IKAPP.Domain.Entities.AggregateModels.Companies;
using IKAPP.Domain.Entities.AggregateModels.Companies.CompanyDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Mapping.CompanyMapping;

public class CompanyMapping : Profile
{
    public CompanyMapping()
    {

        CreateMap<CompanyDTO, CompanyCreateCommand>().ReverseMap();
        CreateMap<CompanyDTO, CompanyEditCommand>().ReverseMap();
        CreateMap<CompanyDTO, CompanyViewDTO>().ReverseMap();
        CreateMap<CompanyEditCommand, CompanyViewDTO>().ReverseMap();
    }
}
