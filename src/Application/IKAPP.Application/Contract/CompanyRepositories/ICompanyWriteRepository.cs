using IKAPP.Application.Contract.Common;
using IKAPP.Domain.Entities.AggregateModels.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Contract.CompanyRepositories;

public interface ICompanyWriteRepository:IWriteRepository<Company>
{
}
