using IKAPP.Application.Contract.Common;
using IKAPP.Domain.Entities.AggregateModels.Advances;
using IKAPP.Domain.Entities.AggregateModels.Personals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Contract.AdvanceRepositories;

public interface IAdvanceWriteRepository:IWriteRepository<Advance>
{
    Task<Tuple<Personal, Advance>> ControlofAdvance(Personal personel, Advance advance);
}
