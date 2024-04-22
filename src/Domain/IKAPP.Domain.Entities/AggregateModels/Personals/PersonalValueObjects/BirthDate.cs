using IKAPP.Domain.Entities.AggregateModels.Personals.PersonalRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.AggregateModels.Personals.PersonalValueObjects;

public sealed record BirthDate
{
    private readonly PersonalRule rules;

    public BirthDate(DateTime birthDate)
    {
        rules = new();
        rules.BirthDateRules(birthDate);
        Value = birthDate;
    }
    public DateTime Value { get; set; }
}
