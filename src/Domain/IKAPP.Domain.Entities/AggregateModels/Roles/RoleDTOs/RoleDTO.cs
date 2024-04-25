using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.AggregateModels.Roles.RoleDTOs;

public sealed record RoleDTO
{
    public string? Id { get; init; }
    public string Name { get; init; }
}
