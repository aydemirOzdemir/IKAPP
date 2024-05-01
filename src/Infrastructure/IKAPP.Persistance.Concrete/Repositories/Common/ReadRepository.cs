using IKAPP.Application.Contract.Common;
using IKAPP.Domain.Entities.Enums;
using IKAPP.Domain.Entities.Interfaces;
using IKAPP.Domain.Entities.SeedWorks.Base;
using IKAPP.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Persistance.Concrete.Repositories.Common;

public class ReadRepository<T>:IReadRepository<T> where T : AuditableEntity
{
    protected readonly IKAPPDbContext dbContext;
    protected readonly DbSet<T> dbSet;

    public ReadRepository(IKAPPDbContext dbContext)
    {
        this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        dbSet = dbContext.Set<T>() ?? throw new ArgumentNullException("DbContext is null");
    }

    public Task<bool> AnyAsync(Expression<Func<T, bool>>? expression = null)
    {
        return expression is null ? GetAllActives().AnyAsync() : GetAllActives().AnyAsync(expression);
    }

    public async Task<int> CountAsync(Expression<Func<T, bool>>? expression = null)
    {
        dbSet.AsNoTracking();
        if (expression is not null)
            return await dbSet.Where(expression).CountAsync();
        return await dbSet.CountAsync();
    }

    public IQueryable<T> Find(Expression<Func<T, bool>> expression, bool tracking = true)
    {
        if (!tracking) dbSet.AsNoTracking();
        return dbSet.Where(expression);
    }

    public async Task<IEnumerable<T>> GetAllAsync<TKey>(Expression<Func<T, TKey>> orderby, bool orderDesc = false, bool tracking = true)
    {
        var values = GetAllActives(tracking);

        return orderDesc ? await values.OrderByDescending(orderby).ToListAsync() : await values.OrderBy(orderby).ToListAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync<TKey>(Expression<Func<T, bool>> expression, Expression<Func<T, TKey>> orderby, bool orderDesc = false, bool tracking = true)
    {
        var values = GetAllActives(tracking).Where(expression);

        return orderDesc ? await values.OrderByDescending(orderby).ToListAsync() : await values.OrderBy(orderby).ToListAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool traking = true)
    {
        IQueryable<T> queryable = dbSet;
        if (!traking) queryable = queryable.AsNoTracking();
        if (include is not null) queryable = include(queryable);
        if (expression is not null) queryable = queryable.Where(expression);
        if (orderBy is not null)
            return await orderBy(queryable).ToListAsync();
        return await queryable.ToListAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync(bool tracking = true)
    {
        return await GetAllActives(tracking).ToListAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression, bool tracking = true)
    {
        return await GetAllActives(tracking).Where(expression).ToListAsync();
    }

    public async Task<IEnumerable<T>> GetAllByPagingAsync(Expression<Func<T, bool>>? expression = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = true, int currentPage = 1, int pageSize = 3)
    {
        IQueryable<T> queryable = dbSet;
        if (!enableTracking) queryable = queryable.AsNoTracking();
        if (include is not null) queryable = include(queryable);
        if (expression is not null) queryable = queryable.Where(expression);
        if (orderBy is not null)
            return await orderBy(queryable).Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();
        return await queryable.Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();
    }

  

    public async Task<T> GetAsync(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool tracking = true)
    {
        IQueryable<T> queryable = dbSet;
        if (!tracking) queryable = queryable.AsNoTracking();
        if (include is not null) queryable = include(queryable);

        return await queryable.FirstOrDefaultAsync(expression);
    }

    public Task<T?> GetByIdAsync(string id, bool tracking = true)
    {
        var values = GetAllActives(tracking);

        return values.FirstOrDefaultAsync(x => x.Id == id);
    }

    public IQueryable<T> GetQueryable()
    {
        return dbSet.AsQueryable();
    }
    protected IQueryable<T> GetAllActives(bool tracking = true)
    {
        var values = dbSet.Where(x => x.Status != Status.Deleted);

        return tracking ? values : values.AsNoTracking();
    }
}
