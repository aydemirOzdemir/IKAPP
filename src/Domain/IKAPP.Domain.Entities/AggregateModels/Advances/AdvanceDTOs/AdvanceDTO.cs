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
 
    public string Id { get;  set; }
    public DateTime RequestDate { get;  set; }
    public string Name { get; set; }
    public DateTime DateofReply { get; set; }
    public Approval StatusofApproval { get; set; }
    public decimal TotalAmount { get;  set; }
    public Currency Currency { get;  set; }
    public TypeofAdvance TypeofAdvance { get;  set; }
    public string Description { get;  set; }
    public string PersonalId { get;  set; }
    public string? CompanyId { get;  set; }
    public Personal Personal { get;  set; }
    public Company? Company { get;  set; }
}
