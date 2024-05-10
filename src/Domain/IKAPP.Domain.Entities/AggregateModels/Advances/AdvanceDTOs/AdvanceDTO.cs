using IKAPP.Domain.Entities.AggregateModels.Advances.AdvanceValueObjects;
using IKAPP.Domain.Entities.AggregateModels.Companies;
using IKAPP.Domain.Entities.AggregateModels.Personals;
using IKAPP.Domain.Entities.Enums;
using IKAPP.Domain.SeedWorks.Base.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.AggregateModels.Advances.AdvanceDTOs;

public sealed record AdvanceDTO
{

    public string Id { get; set; } = null!;
    public DateTime? RequestDate { get; set; } = default!;
    public string Name { get; set; } = null!;
    public DateTime? DateofReply { get; set; }
    public Approval? StatusofApproval { get; set; }
    public decimal TotalAmount { get; set; } 
    public Currency Currency { get; set; } = default!;
    public TypeofAdvance TypeofAdvance { get;  set; } = default!;
    public string Description { get; set; } = default!;
    public string PersonalId { get;  set; } = default!;
    public string? CompanyId { get;  set; }
    public Personal Personal { get; set; } = null!;
    public Company? Company { get;  set; }
}
