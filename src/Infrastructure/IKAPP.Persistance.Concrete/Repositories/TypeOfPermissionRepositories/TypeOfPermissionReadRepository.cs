using IKAPP.Application.Contract.TypeOfPermissionRepositories;
using IKAPP.Domain.Entities.AggregateModels.TypeofPermissions;
using IKAPP.Persistance.Concrete.Repositories.Common;
using IKAPP.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Persistance.Concrete.Repositories.TypeOfPermissionRepositories;

public class TypeofPermissionReadRepository : ReadRepository<TypeofPermission>, ITypeofPermissionReadRepository
{
    public TypeofPermissionReadRepository(IKAPPDbContext context) : base(context) { }

}
