using IKAPP.Application.Contract.Common;
using IKAPP.Domain.Entities.AggregateModels.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Contract.PermissionRepositories;

public interface IPermissionWriteRepository:IWriteRepository<Permission>
{
}
