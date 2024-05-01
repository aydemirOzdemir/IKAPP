using IKAPP.Domain.Entities.Interfaces;
using IKAPP.Domain.Entities.SeedWorks.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Contract.Common.Interfaces;

public interface IAsyncQueryableRepository<TEntity> where TEntity : AuditableEntity
{
    Task<IEnumerable<TEntity>> GetAllAsync(bool tracking = true);
    Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression, bool tracking = true);
    IQueryable<TEntity> GetQueryable();
    IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression, bool tracking = true);
}
