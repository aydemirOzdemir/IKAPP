using IKAPP.Application.Contract.Common.Interfaces;
using IKAPP.Domain.Entities.SeedWorks.Base;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Contract.Common;

public interface IReadRepository<T>:IAsyncOrderableRepository<T>,IAsyncFindableRepository<T>,IAsyncQueryableRepository<T> where T : AuditableEntity
{
    Task<IEnumerable<T>> GetAllInclude(
       Expression<Func<T, bool>>? expression = null,
       Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
       CancellationToken token = default);
    Task<T> GetSingleInclude(
   Expression<Func<T, bool>>? expression = null,
   Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
   CancellationToken token = default);

}
