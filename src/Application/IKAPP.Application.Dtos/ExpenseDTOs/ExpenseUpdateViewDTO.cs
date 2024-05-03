using IKAPP.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Dtos.ExpenseDTOs;

public class ExpenseUpdateViewDTO
{
    public string Id { get; set; }

    public decimal TotalAmount { get; set; }
    public Currency Currency { get; set; }
    public TypeofExpenses TypeofExpenses { get; set; }
    public string Documantation { get; set; }
}
