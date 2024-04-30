using IKAPP.Application.Contract.Common;
using IKAPP.Domain.Entities.AggregateModels.TypeofPermissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Contract.TypeOfPermissionRepositories;

public interface ITypeofPermissionReadRepository:IReadRepository<TypeofPermission>
{
}
