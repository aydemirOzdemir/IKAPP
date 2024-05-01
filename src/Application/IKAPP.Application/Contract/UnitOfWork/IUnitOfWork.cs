using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Contract.UnitOfWork;

public interface IUnitOfWork<ITReadRepository, ITWriteRepository> : IAsyncDisposable
{
    ITReadRepository ReadRepository { get; }
    ITWriteRepository WriteRepository { get; }
    Task<int> SaveAsync();
    int Save();
}
