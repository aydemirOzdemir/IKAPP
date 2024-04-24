using IKAPP.Domain.Entities.AggregateModels.Advances.AdvanceValueObjects;
using IKAPP.Domain.Entities.AggregateModels.Companies;
using IKAPP.Domain.Entities.AggregateModels.Personals;
using IKAPP.Domain.Entities.Enums;
using IKAPP.Domain.SeedWorks.Base.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.AggregateModels.Expenses.ExpenseDTOs;

public sealed record ExpenseDTO
{
    public string Id { get; init; }
    public DateTime RequestDate { get; init; }
    public string Name { get; init; }
    public DateTime DateofReply { get; init; }
    public Approval StatusofApproval { get; init; }
    public decimal TotalAmount { get;  init; }
    public Currency Currency { get; init; }
    public TypeofExpenses TypeofExpense { get; init; }
    public string Documantation { get; init; }
    public string PersonalId { get; init; }
    public string? CompanyId { get; init; }
    public Personal Personal { get; init; }
    public Company? Company { get; init; }
}
