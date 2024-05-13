using IKAPP.Application.Bases;
using IKAPP.Application.Features.CompanyFeatures.CompanyExceptions;
using IKAPP.Domain.Entities.AggregateModels.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Features.CompanyFeatures.CompanyRules;

public class CompanyRuleForApplication:BaseRuleForApplication
{
    public Task CompanyShouldNotBeNull(Company? company) 
    {
        if (company == null)
            throw new CompanyShouldNotBeNullException("Şirket bulunamadı");
        return Task.CompletedTask; 
    }
}
