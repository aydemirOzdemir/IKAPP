using IKAPP.Domain.Entities.AggregateModels.Roles.RoleDTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.AggregateModels.Roles;

public  class Role:IdentityRole
{
    public Role(RoleDTO roleDTO)
    {
        Name = roleDTO.Name;
    }
    public static Role CreateRole(RoleDTO roleDTO)=> new Role(roleDTO);
    public  RoleDTO CreateRoleDTO()=> new RoleDTO()
    {
        Id=this.Id,
        Name=this.Name
    };

}
