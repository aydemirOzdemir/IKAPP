using IKAPP.Domain.Entities.SeedWorks.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Contract.Common;

public interface IWriteRepository<T> where T : AuditableEntity
{
    bool Update(T entity, CancellationToken token);

    bool RemoveById(string id, CancellationToken token);

    Task<bool> AddAsync(T entity, CancellationToken token);
    Task<int> SaveAsync(CancellationToken token);
}
