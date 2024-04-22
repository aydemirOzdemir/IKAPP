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
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.AggregateModels.Advances;

public  class Advance:BaseEntityForBusiness,IAggregateRoot
{
    private readonly AdvanceRule rules;
    public Advance(string id,Name name,TotalAmount totalAmount,Currency currency,TypeofAdvance typeofAdvance,string description,string personalId,string? companyId,Personal personal,Company? company):base(id, name)
    {
        rules= new();
        rules.CurrencyCanNotBeEmpty(currency);
        rules.TypeofAdvanceCanNotBeEmpty(typeofAdvance);
        rules.DescriptionCanNotBeEmpty(description);
        rules.PersonalIdCanNotBeEmpty(personalId);
        TotalAmount = totalAmount;
        Currency = currency;
        TypeofAdvance = typeofAdvance;
        Description = description;
        PersonalId = personalId;
        CompanyId = companyId;
        Personal = personal;
        Company = company;
    }
 
    public TotalAmount TotalAmount { get;  private set; }
    public Currency Currency { get; private set; }
    public TypeofAdvance TypeofAdvance { get; private set; }
    public string Description { get; private set; }
    public string PersonalId { get; private set; }
    public string? CompanyId { get; private set; }
    public Personal Personal { get; private set; }
    public Company? Company { get; private set; }

 

}
