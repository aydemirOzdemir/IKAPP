using IKAPP.Domain.Entities.AggregateModels.Personals.PersonalRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.AggregateModels.Personals.PersonalValueObjects;

public sealed record IdentityNumber
{
    private readonly PersonalRule rules;

    public IdentityNumber(string identityNumber)
    {
        rules = new();
        rules.IdentityNumberCanNotBeEmpty(identityNumber);
        rules.IdentityNumberLengthMustBe11(identityNumber);
        rules.IdentityNumberMustBeValid(identityNumber);
        Value=identityNumber;
    }
    public string Value {  get; set; }
}
