using IKAPP.Domain.Entities.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.SeedWorks.Base.Shared;

public sealed record Name
{
    private readonly SharedRule rules;

    public string Value { get; private set; }
    public Name(string? value)
    {
        rules = new();
        rules.NamespaceCanNotBeEmpty(value);
        rules.NamespaceMustBeAtLeast3CharactersLong(value);
        Value = value;
    }
  
}
