using IKAPP.Domain.Entities.Enums;
using IKAPP.Domain.Entities.Interfaces;
using IKAPP.Domain.SeedWorks.Base.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.SeedWorks.Base;

public abstract class BaseEntity : IEntity, ICreateableEntity, IUpdateableEntity, IEquatable<BaseEntity>
{
    public BaseEntity(string id, Name name)
    {
        Id = id;
        Name = name;

    }
    public Name Name { get; private set; }
    public DateTime? CreatedDate { get; private set; }
    public string Id { get; private set; }
    public Status? Status { get; private set; }
    public DateTime? ModifiedDate { get; private set; }

    public bool Equals(BaseEntity? other)
    {
        if (other == null) return false;
        if (other is not BaseEntity entity) return false;
        if (other.GetType() != GetType()) return false;
        return entity.Id == Id;
    }

    public void UpdateBaseEntiy(Name? name,DateTime? createdTime,string? id, Status? status,DateTime? modifiedDate)
    {
        if(name!=null) Name= name;
        if (createdTime != null) CreatedDate = createdTime;
        if (id != null) Id = id;
        if (status != null) Status = status;
        if (modifiedDate != null) ModifiedDate = modifiedDate;
    }
}
