using IKAPP.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.AggregateModels.Expenses.ExpenseDTOs;

public sealed record ExpenseUpdateDTO
{
    public string Id { get; set; }

    public decimal TotalAmount { get; set; }
    public Currency Currency { get; set; }
    public TypeofExpenses TypeofExpenses { get; set; }
    public string Documantation { get; set; }
}
