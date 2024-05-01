using IKAPP.Application.Contract.Common.Interfaces;
using IKAPP.Domain.Entities.SeedWorks.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Contract.Common;

public interface IWriteRepository<T> :IDeleteableRepository<T>,IAsyncInsertableRepository<T>,IAsyncDeleteableRepository<T>,IAsyncUpdateableRepository<T> where T : AuditableEntity
{
}
