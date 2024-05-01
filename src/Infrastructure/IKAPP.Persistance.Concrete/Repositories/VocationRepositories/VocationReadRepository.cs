using IKAPP.Application.Contract.VocationRepositories;
using IKAPP.Domain.Entities.AggregateModels.Vocations;
using IKAPP.Persistance.Concrete.Repositories.Common;
using IKAPP.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Persistance.Concrete.Repositories.VocationRepositories;

public class VocationReadRepository : ReadRepository<Vocation>, IVocationReadRepository
{
    public VocationReadRepository(IKAPPDbContext dbContext) : base(dbContext) { }
}