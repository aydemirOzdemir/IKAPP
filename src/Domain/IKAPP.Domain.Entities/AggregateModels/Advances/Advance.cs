using IKAPP.Domain.Entities.AggregateModels.Advances.AdvanceDTOs;
using IKAPP.Domain.Entities.AggregateModels.Advances.AdvanceRules;
using IKAPP.Domain.Entities.AggregateModels.Advances.AdvanceValueObjects;
using IKAPP.Domain.Entities.AggregateModels.Companies;
using IKAPP.Domain.Entities.AggregateModels.Personals;
using IKAPP.Domain.Entities.Enums;
using IKAPP.Domain.Entities.SeedWorks;
using IKAPP.Domain.Entities.SeedWorks.Base;
using IKAPP.Domain.SeedWorks.Base.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.AggregateModels.Advances;

public class Advance : BaseEntityForBusiness, IAggregateRoot
{
    private readonly AdvanceRule rules;
    private Advance(AdvanceDTO advanceDTO) : base(advanceDTO.Id, new(advanceDTO.Name))
    {
        rules = new();
        rules.CurrencyCanNotBeEmpty(advanceDTO.Currency);
        rules.TypeofAdvanceCanNotBeEmpty(advanceDTO.TypeofAdvance);
        rules.DescriptionCanNotBeEmpty(advanceDTO.Description);
        rules.PersonalIdCanNotBeEmpty(advanceDTO.PersonalId);
        TotalAmount = new(advanceDTO.TotalAmount);
        Currency = advanceDTO.Currency;
        TypeofAdvance = advanceDTO.TypeofAdvance;
        Description = advanceDTO.Description;
        PersonalId = advanceDTO.PersonalId;
        CompanyId = advanceDTO.CompanyId;
        Personal = advanceDTO.Personal;
        Company = advanceDTO.Company;
        StatusofApproval = advanceDTO.StatusofApproval;
        DateofReply = advanceDTO.DateofReply;
        RequestDate = advanceDTO.RequestDate;

    }

    public TotalAmount TotalAmount { get; private set; }
    public Currency Currency { get; private set; }
    public TypeofAdvance TypeofAdvance { get; private set; }
    public string Description { get; private set; }
    public string PersonalId { get; private set; }
    public string? CompanyId { get; private set; }
    public Personal Personal { get; private set; }
    public Company? Company { get; private set; }

    public static Advance CreateAdvance(AdvanceDTO advanceDTO) => new(advanceDTO) { CreatedDate = DateTime.Now };

    public AdvanceDTO CreateAdvanceDTO() => new AdvanceDTO()
    {
        Id = this.Id,
        RequestDate = this.RequestDate,
        Name = this.Name.Value,
        DateofReply = this.DateofReply,
        StatusofApproval = this.StatusofApproval,
        TotalAmount = this.TotalAmount.Value,
        Currency = this.Currency,
        TypeofAdvance = this.TypeofAdvance,
        Description = this.Description,
        PersonalId = this.PersonalId,
        CompanyId = this.CompanyId,
        Personal = this.Personal,
        Company = this.Company,
    };


}



