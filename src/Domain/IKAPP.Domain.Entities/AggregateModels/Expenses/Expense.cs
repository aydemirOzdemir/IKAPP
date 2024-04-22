using IKAPP.Domain.Entities.AggregateModels.Advances.AdvanceValueObjects;
using IKAPP.Domain.Entities.AggregateModels.Companies;
using IKAPP.Domain.Entities.AggregateModels.Expenses.ExpenseRules;
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

namespace IKAPP.Domain.Entities.AggregateModels.Expenses;

public  class Expense:BaseEntityForBusiness,IAggregateRoot
{
    private readonly ExpenseRule rules;

    public Expense(string id, Name name,TotalAmount totalAmount,Currency currency,TypeofExpenses typeofExpenses,string documantation,string personalId,string? companyId,Personal personal,Company? company) : base(id, name)
    {
        rules = new();
        TotalAmount = totalAmount;
        rules.CurrencyCanNotBeEmpty(currency);
        Currency = currency;
        rules.PersonalIdCanNotBeEmpty(personalId);
        PersonalId = personalId;
        rules.DocumantationCanNotBeEmpty(documantation);
        Documantation = documantation;
        rules.TypeofExpenseCanNotBeEmpty(typeofExpenses);
        TypeofExpense = typeofExpenses;
        CompanyId = companyId;
        Personal= personal;
        Company= company;
        
    }
    public TotalAmount TotalAmount { get; private set; }
    public Currency Currency { get; private set; }
    public TypeofExpenses TypeofExpense { get; private set; }
    public string Documantation { get; private set; }
    public string PersonalId { get; private set; }
    public string? CompanyId { get; private set; }
    public Personal Personal { get; private set; }
    public Company? Company { get; private set; }
   
}
