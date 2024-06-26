﻿using IKAPP.Domain.Entities.Interfaces;
using IKAPP.Domain.SeedWorks.Base.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.SeedWorks.Base;

public abstract class AuditableEntity : BaseEntity, ISoftDeleteEntity
{
    public AuditableEntity(string id,Name name) : base(id,name) { }

    public DateTime? DeletedDate { get; private  set; }
    public void UpdateDeleteDate(DateTime? deletedDate)
    {
        if(deletedDate!=null)
        DeletedDate = deletedDate;
    }
}
