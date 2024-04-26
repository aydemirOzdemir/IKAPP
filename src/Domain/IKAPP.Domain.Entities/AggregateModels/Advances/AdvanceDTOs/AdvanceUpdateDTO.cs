using IKAPP.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.AggregateModels.Advances.AdvanceDTOs;

public sealed record AdvanceUpdateDTO
{
    public string Id { get; set; }
    public decimal TotalAmount { get; init; } = default!;
    public Currency Currency { get; init; } = default!;
    public TypeofAdvance TypeofAdvance { get; init; } = default!;
    public string Description { get; init; } = default!;
}
