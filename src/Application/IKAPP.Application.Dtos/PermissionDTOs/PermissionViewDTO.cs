using IKAPP.Application.Dtos.CompanyDTOs;
using IKAPP.Application.Dtos.PersonalDTOs;
using IKAPP.Application.Dtos.TypeOfPermissionDTOs;
using IKAPP.Domain.Entities.AggregateModels.Personals.PersonalDTOs;
using IKAPP.Domain.Entities.AggregateModels.TypeofPermissions;
using IKAPP.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Dtos.PermissionDTOs;

public class PermissionViewDTO
{
    public string Id { get; set; }
    public string Name { get; set; } = default!;
    public DateTime RequestDate { get; set; } = DateTime.UtcNow;

    public DateTime DateofReply { get; set; }
    public Approval StatusofApproval { get; set; } = Approval.AwaitingApproval;
    public DateTime StartedDate { get; set; }
    public DateTime FinishedDate { get; set; }
    public byte DayCount { get; set; }
    public string TypeofPermissionId { get; set; }
    public string PersonelId { get; set; }
    public string CompanyId { get; set; } //++
    public CompanyViewDTO CompanyViewModel { get; set; }

    

  

    public PersonalDTO Personal { get; set; }
    public TypeOfPermissionViewDTO TypeofPermissionViewDTO { get; set; }
    public PersonalViewDTO PersonelViewDTO { get; set; }
}
