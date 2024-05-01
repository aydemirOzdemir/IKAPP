using IKAPP.Application.Contract.Common;
using IKAPP.Domain.Entities.SeedWorks.Base;
using IKAPP.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Persistance.Concrete.Repositories.Common;

public class WriteRepository<T>:IWriteRepository<T> where T : AuditableEntity
{
    protected readonly IKAPPDbContext dbContext;
    private readonly DbSet<T> dbSet;

    public WriteRepository(IKAPPDbContext dbContext)
    {
        this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        dbSet = dbContext.Set<T>() ?? throw new ArgumentNullException("DbContext is null");
    }

    public async Task<T> AddAsync(T entity)
    {
        var entry = await dbSet.AddAsync(entity);

        return entry.Entity;
    }

    public Task AddRangeAsync(IEnumerable<T> entities)
    {
        return dbSet.AddRangeAsync(entities);
    }

    public void Delete(T entity)
    {
       dbSet.Remove(entity);
    }

    public Task DeleteAsync(T entity)
    {
        return Task.FromResult(dbSet.Remove(entity));
    }

    public async Task<T> UpdateAsync(T entity)
    {
        var entry = await Task.FromResult(dbSet.Update(entity));
        return entry.Entity;
    }
}
