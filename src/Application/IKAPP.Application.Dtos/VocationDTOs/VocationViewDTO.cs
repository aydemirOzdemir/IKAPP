using IKAPP.Application.Dtos.CompanyDTOs;
using IKAPP.Application.Dtos.PersonalDTOs;
using IKAPP.Domain.Entities.AggregateModels.Personals.PersonalDTOs;
using IKAPP.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Dtos.VocationDTOs;

public class VocationViewDTO
{
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public bool IsActive { get; set; }
}
