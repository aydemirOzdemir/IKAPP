using IKAPP.Domain.Entities.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.AggregateModels.Permissions.Exception;

public class TypeofPermissionIdCanNotBeEmptyException:BaseException
{
    public TypeofPermissionIdCanNotBeEmptyException(string message):base(message)
    {}
}
public class PermissionTimeCanNotBeEmptyException : BaseException
{
    public PermissionTimeCanNotBeEmptyException(string message) : base(message)
    { }
}
