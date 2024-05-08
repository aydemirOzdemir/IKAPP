using IKAPP.Domain.Entities.Enums;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.AdvanceFeatures.AdvanceCommands.AdvanceEdit;

public class AdvanceEditCommand:IRequest<IResult>
{
    public string Id { get; set; }

    public decimal TotalAmount { get; set; }
    public Currency Currency { get; set; }
    public TypeofAdvance TypeofAdvance { get; set; }
    public string Description { get; set; }
}
