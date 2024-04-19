using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.Interfaces;

public interface ISoftDeleteEntity
{
    string? DeletedBy { get; set; }
    DateTime? DeletedDate { get; set; }
}
