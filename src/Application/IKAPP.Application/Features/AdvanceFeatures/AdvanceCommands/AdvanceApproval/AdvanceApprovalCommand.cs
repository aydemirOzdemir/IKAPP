using IKAPP.Application.Dtos.AdvanceDTOs;
using IKAPP.Domain.Entities.Enums;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.AdvanceFeatures.AdvanceCommands.AdvanceApproval;

public class AdvanceApprovalCommand:IRequest<IDataResult<AdvanceViewDTO>>
{
    public string Id { get; set; }
    public Approval StatusofApproval { get; set; }
    public string PersonelId { get; set; }
    public string PersonelName { get; set; }
}
