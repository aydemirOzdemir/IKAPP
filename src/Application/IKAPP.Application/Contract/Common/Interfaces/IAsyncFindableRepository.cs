using IKAPP.Domain.Entities.SeedWorks.Base;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Contract.Common.Interfaces;

public interface IAsyncFindableRepository<TEntity>:IAsyncQueryableRepository<TEntity> where TEntity : AuditableEntity
{
    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, bool tracking = true);
    Task<TEntity?> GetByIdAsync(string id, bool tracking = true);
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? expression = null);

    Task<int> CountAsync(Expression<Func<TEntity, bool>>? expression = null);
}
