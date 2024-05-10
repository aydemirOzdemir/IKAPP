using IKAPP.Application.Contract.AdvanceRepositories;
using IKAPP.Domain.Entities.AggregateModels.Advances;
using IKAPP.Domain.Entities.AggregateModels.Personals;
using IKAPP.Domain.Entities.Enums;
using IKAPP.Persistance.Concrete.Repositories.Common;
using IKAPP.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Persistance.Concrete.Repositories.AdvanceRepositories;

public class AdvanceWriteRepository:WriteRepository<Advance>,IAdvanceWriteRepository
{
    public AdvanceWriteRepository(IKAPPDbContext context) : base(context) { }

    public async Task<Tuple<Personal, Advance>> ControlofAdvance(Personal personel, Advance advance)
    {
        if (DateTime.Now > personel.AdvanceRenewalDate || personel.AdvanceRenewalDate == null)
        {
            personel.UpdateNumberOfAdvance(0);
            personel.UpdateUsedOfAdvance(0);
        }
      
        decimal maxAdvance = personel.Salary * 3;
        if (personel.UsedAdvance + advance.TotalAmount.Value <= maxAdvance)
        {

            if (personel.NumberofAdvance == 0)
                personel.UpdateAdvanceRenewalDate(DateTime.Now.AddYears(1));//5 aralık 2024
         
            
            advance.UpdateEntityForBusiines(null,null, Approval.Approved);

          
            personel.UpdateUsedOfAdvance(personel.UsedAdvance+advance.TotalAmount.Value);
            personel.UpdateNumberOfAdvance(personel.NumberofAdvance+1);
        }
        else
            
        advance.UpdateEntityForBusiines(null, null, Approval.Denied);

        return new Tuple<Personal, Advance>(personel, advance);
    }
}
