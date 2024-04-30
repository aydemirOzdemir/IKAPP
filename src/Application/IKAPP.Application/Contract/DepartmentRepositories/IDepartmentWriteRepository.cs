using IKAPP.Application.Contract.Common;
using IKAPP.Domain.Entities.AggregateModels.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Contract.DepartmentRepositories;

public interface IDepartmentWriteRepository:IWriteRepository<Department>
{
}
