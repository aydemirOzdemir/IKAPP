using IKAPP.Application.Contract.PermissionRepositories;
using IKAPP.Domain.Entities.AggregateModels.Permissions;
using IKAPP.Persistance.Concrete.Repositories.Common;
using IKAPP.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Persistance.Concrete.Repositories.PermissionRepositories;

public class PermissionWriteRepository : WriteRepository<Permission>, IPermissionWriteRepository
{
    public PermissionWriteRepository(IKAPPDbContext context) : base(context) { }

}
