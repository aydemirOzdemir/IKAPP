using IKAPP.Application.Contract.AdvanceRepositories;
using IKAPP.Domain.Entities.AggregateModels.Advances;
using IKAPP.Persistance.Concrete.Repositories.Common;
using IKAPP.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Persistance.Concrete.Repositories.AdvanceRepositories;

public class AdvanceReadRepository : ReadRepository<Advance>, IAdvanceReadRepository
{
    public AdvanceReadRepository(IKAPPDbContext context) : base(context) { }

}
