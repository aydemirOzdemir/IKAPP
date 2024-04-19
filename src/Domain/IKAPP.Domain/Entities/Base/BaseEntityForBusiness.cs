using IKAPP.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.Base;

public class BaseEntityForBusiness
{
    public DateTime RequestDate { get; set; } = DateTime.UtcNow;

    public DateTime DateofReply { get; set; }
    public Approval StatusofApproval { get; set; } = Approval.AwaitingApproval;
}
