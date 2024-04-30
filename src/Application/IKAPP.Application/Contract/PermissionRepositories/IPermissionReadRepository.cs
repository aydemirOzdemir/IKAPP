using IKAPP.Application.Contract.Common;
using IKAPP.Domain.Entities.AggregateModels.Permissions;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Contract.PermissionRepositories;

public interface IPermissionReadRepository:IReadRepository<Permission>
{
    Task<IEnumerable<Permission>> GetAllIncludePermission(
     Expression<Func<Permission, bool>>? expression = null,
     Func<IQueryable<Permission>, IIncludableQueryable<Permission, object>>? include = null,
     CancellationToken token = default);
}
