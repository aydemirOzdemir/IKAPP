using IKAPP.Domain.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.Base;

public abstract class AuditableEntity : BaseEntity, ISoftDeleteEntity
{
    public AuditableEntity(Guid id):base(id) { }
    
    public string? DeletedBy { get; set ; }
    public DateTime? DeletedDate { get; set ; }
}
