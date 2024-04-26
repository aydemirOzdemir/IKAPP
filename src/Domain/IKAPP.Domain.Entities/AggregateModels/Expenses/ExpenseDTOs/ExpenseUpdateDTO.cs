using IKAPP.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.AggregateModels.Expenses.ExpenseDTOs;

public sealed record ExpenseUpdateDTO
{
    public string Id { get; set; } = null!;

    public decimal TotalAmount { get; set; }
    public Currency Currency { get; set; }=default!;
    public TypeofExpenses TypeofExpenses { get; set; } = default!;
    public string Documantation { get; set; } = null!;
}
