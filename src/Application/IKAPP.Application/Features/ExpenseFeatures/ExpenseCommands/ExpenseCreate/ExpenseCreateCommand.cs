using IKAPP.Application.Dtos.CompanyDTOs;
using IKAPP.Domain.Entities.Enums;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.ExpenseFeatures.ExpenseCommands.ExpenseCreate;

public class ExpenseCreateCommand:IRequest<IDataResult<ExpenseCreateCommand>>
{
    public decimal TotalAmount { get; set; }
    public Currency Currency { get; set; }
    public TypeofExpenses TypeofExpenses { get; set; }
    public string Documantation { get; set; }
    public string? UserName { get; set; }
    public string? CompanyId { get; set; } //++
    public CompanyViewDTO? CompanyViewModel { get; set; }
}
