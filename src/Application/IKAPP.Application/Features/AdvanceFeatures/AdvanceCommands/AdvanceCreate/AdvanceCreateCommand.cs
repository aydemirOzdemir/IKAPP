using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKAPP.Application.Dtos.CompanyDTOs;
using IKAPP.Domain.Entities.Enums;
using IKAPP.Domain.Ultities.Responses;
using MediatR;

namespace IKAPP.Application.Features.AdvanceFeatures.AdvanceCommands.AdvanceCreate;

public class AdvanceCreateCommand:IRequest<IResult>
{
    public decimal TotalAmount { get; set; }
    public Currency Currency { get; set; }
    public TypeofAdvance TypeofAdvance { get; set; }
    public string Description { get; set; }
    public string? CompanyId { get; set; } //++
    public CompanyViewDTO? CompanyViewDTO { get; set; }
}
