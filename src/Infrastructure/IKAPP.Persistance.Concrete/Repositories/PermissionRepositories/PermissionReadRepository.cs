using IKAPP.Application.Contract.PermissionRepositories;
using IKAPP.Domain.Entities.AggregateModels.Permissions;
using IKAPP.Persistance.Concrete.Repositories.Common;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using IKAPP.Persistance.Context;

namespace IKAPP.Persistance.Concrete.Repositories.PermissionRepositories;

public class PermissionReadRepository : ReadRepository<Permission>, IPermissionReadRepository
{
    public PermissionReadRepository(IKAPPDbContext context) : base(context) { }

    public async Task<IEnumerable<Permission>> GetAllIncludePermission(
    Expression<Func<Permission, bool>>? expression = null,
    Func<IQueryable<Permission>, IIncludableQueryable<Permission, object>>? include = null,
    CancellationToken token = default)
    {
        IQueryable<Permission> query = dbSet.AsQueryable();

        if (expression != null)
        {
            query = query.Where(expression);
        }

        if (include != null)
        {
            query = include(query);
        }

        return await query.ToListAsync(token);
    }
}
