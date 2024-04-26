using IKAPP.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.AggregateModels.Vocations.VocationDTOs;

public sealed record VocationUpdateDTO
{
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;
}
