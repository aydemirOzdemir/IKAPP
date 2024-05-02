using IKAPP.Application.Dtos.CompanyDTOs;
using IKAPP.Application.Dtos.PersonalDTOs;
using IKAPP.Domain.Entities.AggregateModels.Personals.PersonalDTOs;
using IKAPP.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Dtos.ExpenseDTOs;

public class ExpenseViewDTO
{
    public string Id { get; set; }
    public string Name { get; set; } = default!;
    public DateTime RequestDate { get; set; } = DateTime.UtcNow;

    public DateTime DateofReply { get; set; }
    public Approval StatusofApproval { get; set; } = Approval.AwaitingApproval;
    public decimal TotalAmount { get; set; }
    public Currency Currency { get; set; }
    public TypeofExpenses TypeofExpenses { get; set; }
    public string Documantation { get; set; }
    public string PersonelId { get; set; }
    public string PersonelName { get; set; }
    public PersonalViewDTO PersonelViewModel { get; set; }

    public PersonalDTO Personal { get; set; }
    public string CompanyId { get; set; } //++
    public CompanyViewDTO CompanyViewModel { get; set; }
}
