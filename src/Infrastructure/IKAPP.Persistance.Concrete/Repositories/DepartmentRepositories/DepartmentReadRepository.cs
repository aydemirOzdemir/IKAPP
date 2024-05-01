using IKAPP.Application.Contract.DepartmentRepositories;
using IKAPP.Domain.Entities.AggregateModels.Departments;
using IKAPP.Persistance.Concrete.Repositories.Common;
using IKAPP.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Persistance.Concrete.Repositories.DepartmentRepositories;

public class DepartmentReadRepository : ReadRepository<Department>, IDepartmentReadRepository
{
    public DepartmentReadRepository(IKAPPDbContext dbContext) : base(dbContext) { }
}
