using IKAPP.Domain.Entities.Enums;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.ExpenseFeatures.ExpenseCommands.ExpenseEdit;

public class ExpenseEditCommand:IRequest<IDataResult<ExpenseEditCommand>>
{
    public string Id { get; set; }

    public decimal TotalAmount { get; set; }
    public Currency Currency { get; set; }
    public TypeofExpenses TypeofExpenses { get; set; }
    public string Documantation { get; set; }
}
