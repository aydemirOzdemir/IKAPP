using IKAPP.Application.Contract.ExpenseRepositories;
using IKAPP.Domain.Entities.AggregateModels.Expenses;
using IKAPP.Persistance.Concrete.Repositories.Common;
using IKAPP.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IKAPP.Persistance.Concrete.Repositories.ExpenseRepositories;

public class ExpenseWriteRepository : WriteRepository<Expense>, IExpenseWriteRepository
{
    public ExpenseWriteRepository(IKAPPDbContext context) : base(context) { }

}
