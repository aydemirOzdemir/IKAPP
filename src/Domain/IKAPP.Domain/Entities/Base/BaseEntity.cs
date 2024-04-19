using IKAPP.Domain.Entities.Enums;
using IKAPP.Domain.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.Base;

public abstract class BaseEntity : IEntity, ICreateableEntity, IUpdateableEntity,IEquatable<BaseEntity>
{
    public BaseEntity(Guid id)
    {
        this.Id = id; 
    }
    public string CreatedBy { get; set; }
    public DateTime CreatedDate { get ; set ; }
    public Guid Id { get ; set ; }
    public Status Status { get ; set ; }
    public string ModifiedBy { get ; set ; }
    public DateTime ModifiedDate { get; set ; }

    public bool Equals(BaseEntity? other)
    {
        if (other == null) return false;
        if (other is not BaseEntity entity) return false;
        if (other.GetType() != GetType()) return false;
        return entity.Id == Id;
    }
}
