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
        RequestDate = DateTime.Now;
        StatusofApproval = Approval.AwaitingApproval;
    }
    public DateTime? RequestDate { get; private set; }

    public DateTime? DateofReply { get; private set; }
    public Approval? StatusofApproval { get;private set; }

    public void UpdateEntityForBusiines(DateTime? requestDate,DateTime? dateofReply,Approval? approval)
    {
        if(requestDate!=null)
            RequestDate = requestDate;
        if(dateofReply!=null)
            DateofReply = dateofReply;
        if (approval != null)
            StatusofApproval = approval;

    }
}
