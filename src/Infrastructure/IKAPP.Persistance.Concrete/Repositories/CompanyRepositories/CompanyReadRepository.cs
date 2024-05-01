using IKAPP.Application.Contract.CompanyRepositories;
using IKAPP.Domain.Entities.AggregateModels.Companies;
using IKAPP.Persistance.Concrete.Repositories.Common;
using IKAPP.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Persistance.Concrete.Repositories.CompanyRepositories;

public class CompanyReadRepository : ReadRepository<Company>, ICompanyReadRepository
{
    public CompanyReadRepository(IKAPPDbContext dbContext) : base(dbContext) { }

}
