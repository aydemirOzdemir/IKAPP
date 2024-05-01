using IKAPP.Application.Contract.VocationRepositories;
using IKAPP.Domain.Entities.AggregateModels.Vocations;
using IKAPP.Persistance.Concrete.Repositories.Common;
using IKAPP.Persistance.Context;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Persistance.Concrete.Repositories.VocationRepositories;

public class VocationWriteRepository : WriteRepository<Vocation>, IVocationWriteRepository
{
    public VocationWriteRepository(IKAPPDbContext dbContext) : base(dbContext) { }

}
