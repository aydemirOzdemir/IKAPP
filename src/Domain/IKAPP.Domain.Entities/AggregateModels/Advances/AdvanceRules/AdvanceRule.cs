﻿using IKAPP.Domain.Entities.AggregateModels.Advances.Exceptions;
using IKAPP.Domain.Entities.Bases;
using IKAPP.Domain.Entities.Enums;
using IKAPP.Domain.SeedWorks.Base.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.AggregateModels.Advances.AdvanceRules;

public class AdvanceRule:BaseRule
{
    public void BeValidNumber(decimal value)
    {
        if (!decimal.TryParse(value.ToString(),out _))
        {
            throw new BeValidNumberException("Toplam Tutar Sadece Sayısal Değer İçermelidir.");
        }
       
    }
    public void GreaterThan2000(decimal value)
    {
        if (value<2000)
        {
            throw new GreaterThan2000Exception("Toplam Tutar 2000'den büyük olmalıdır.");
        }
       
    }
    public void TotalAmountCanNotBeEmpty(decimal? value)
    {
        if (value == null)
        {
            throw new TotalAmountCanNotBeEmptyException("Toplam Tutar Alanı Boş Bırakılamaz");
        }
     
    }
    public void CurrencyCanNotBeEmpty(Currency? value)
    {
        if (value == null)
        {
            throw new CurrencyCanNotBeEmptyException("Para Birimi Alanı Boş Bırakılamaz");
        }
   
    }
    public void DescriptionCanNotBeEmpty(string? value)
    {
        if (value == null)
        {
            throw new DescriptionCanNotBeEmptyException("Açıklama Alanı Boş Bırakılamaz");
        }
      
    }
    public void TypeofAdvanceCanNotBeEmpty(TypeofAdvance? value)
    {
        if (value == null)
        {
            throw new TypeofAdvanceCanNotBeEmptyException("Avans Tipi Alanı Boş Bırakılamaz");
        }
        
    }
    public void PersonalIdCanNotBeEmpty(string? value)
    {
        if (value == null)
        {
            throw new PersonalIdCanNotBeEmptyException("Personel Kimliği Alanı Boş Bırakılamaz");
        }
        
    }
}
