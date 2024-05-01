using IKAPP.Domain.Entities.SeedWorks.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Contract.Common.Interfaces;

public interface IAsyncDeleteableRepository<TEntity> where TEntity : AuditableEntity
{
    Task DeleteAsync(TEntity entity);
}
