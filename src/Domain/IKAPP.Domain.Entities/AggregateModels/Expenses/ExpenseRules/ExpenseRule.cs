using IKAPP.Domain.Entities.AggregateModels.Advances.Exceptions;
using IKAPP.Domain.Entities.AggregateModels.Expenses.Exceptions;
using IKAPP.Domain.Entities.Bases;
using IKAPP.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.AggregateModels.Expenses.ExpenseRules;

public class ExpenseRule:BaseRule
{
    public Task PersonalIdCanNotBeEmpty(string value)
    {
        if (value == null)
        {
            throw new PersonalIdCanNotBeEmptyException("Personel Kimliği Alanı Boş Bırakılamaz");
        }
        return Task.CompletedTask;
    }
    public Task DocumantationCanNotBeEmpty(string value)
    {
        if (value == null)
        {
            throw new DocumantationCanNotBeEmptyException("Dokumantasyon Alanı Boş Bırakılamaz");
        }
        return Task.CompletedTask;
    }
    public Task CurrencyCanNotBeEmpty(Currency value)
    {
        if (value == null)
        {
            throw new CurrencyCanNotBeEmptyException("Para Birimi Alanı Boş Bırakılamaz");
        }
        return Task.CompletedTask;
    }
    public Task TypeofExpenseCanNotBeEmpty(TypeofExpenses  value)
    {
        if (value == null)
        {
            throw new TypeofExpenseCanNotBeEmptyException("Harcama Türü Alanı Boş Bırakılamaz");
        }
        return Task.CompletedTask;
    }
}
