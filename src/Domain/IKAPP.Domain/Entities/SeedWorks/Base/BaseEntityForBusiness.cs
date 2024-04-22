using IKAPP.Domain.Entities.Enums;
using IKAPP.Domain.SeedWorks.Base.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.SeedWorks.Base;

public class BaseEntityForBusiness : AuditableEntity
{
    public BaseEntityForBusiness(string id,Name name) : base(id,name)
    {
        Id = id;
        RequestDate = DateTime.Now;
        StatusofApproval = Approval.AwaitingApproval;
    }
    public DateTime RequestDate { get; set; }

    public DateTime DateofReply { get; set; }
    public Approval StatusofApproval { get; set; }
}
