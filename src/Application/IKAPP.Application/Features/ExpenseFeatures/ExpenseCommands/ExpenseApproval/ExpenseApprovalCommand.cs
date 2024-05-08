using IKAPP.Application.Dtos.ExpenseDTOs;
using IKAPP.Domain.Entities.Enums;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.ExpenseFeatures.ExpenseCommands.ExpenseApproval;

public class ExpenseApprovalCommand:IRequest<IDataResult<ExpenseViewDTO>>
{
    public string Id { get; set; }

    public Approval StatusofApproval { get; set; }
}

