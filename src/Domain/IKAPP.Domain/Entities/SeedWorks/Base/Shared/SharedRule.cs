using IKAPP.Domain.Entities.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.SeedWorks.Base.Shared;

public class SharedRule:BaseRule
{
    public Task NamespaceCanNotBeEmpty(string value)
    {
        if (value == null)
        {
            throw new NamespaceCanNotBeEmptyException("İsim Alanı Boş Bırakılamaz");
        }
        return Task.CompletedTask;
    }
    public Task NamespaceMustBeAtLeast3CharactersLong (string value)
    {
        if (value.Length<3)
        {
            throw new NamespaceMustBeAtLeast3CharactersLongException("İsim Alanı Boş Bırakılamaz");
        }
        return Task.CompletedTask;
    }
}
