using IKAPP.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.Interfaces;

public interface IEntity
{
    Guid Id { get; set; }
    Status Status { get; set; }
}
