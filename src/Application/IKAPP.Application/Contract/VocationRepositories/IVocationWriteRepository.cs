using IKAPP.Application.Contract.Common;
using IKAPP.Domain.Entities.AggregateModels.Vocations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Contract.VocationRepositories;

public interface IVocationWriteRepository:IReadRepository<Vocation>
{
}
