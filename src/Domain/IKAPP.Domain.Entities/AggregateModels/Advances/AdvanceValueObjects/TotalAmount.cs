using IKAPP.Domain.Entities.AggregateModels.Advances.AdvanceRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.AggregateModels.Advances.AdvanceValueObjects;

public sealed record TotalAmount
{
    private readonly AdvanceRule rules;

    public TotalAmount(decimal value)
    {
        rules = new();
        rules.TotalAmountCanNotBeEmpty(value);
        rules.BeValidNumber(value);
        rules.GreaterThan2000(value); 
    }
    public decimal Value { get; private set; }  
}
