using IKAPP.Application.Contract.Common;
using IKAPP.Domain.Entities.AggregateModels.Advances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Contract.AdvanceRepositories;

public interface IAdvanceReadRepository:IReadRepository<Advance>
{
}
