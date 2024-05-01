using IKAPP.Application.Contract.TypeOfPermissionRepositories;
using IKAPP.Application.Contract.UnitOfWork;
using IKAPP.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Persistance.Concrete.UnitOfWork;

public class UnitOfWork<ITReadRepositoy, ITWriteRepository> : IUnitOfWork<ITReadRepositoy, ITWriteRepository>
{
    private readonly IKAPPDbContext context;

    public UnitOfWork(ITReadRepositoy readRepositoy,ITWriteRepository writeRepository,IKAPPDbContext context)
    {
       
        ReadRepository = readRepositoy;
        WriteRepository = writeRepository;
        this.context = context;
    }
    public ITReadRepositoy ReadRepository { get; }

    public ITWriteRepository WriteRepository { get; }

    public async ValueTask DisposeAsync() => await context.DisposeAsync();

    public int Save() => context.SaveChanges();


    public async Task<int> SaveAsync() => await context.SaveChangesAsync();
}
