using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Domain.Entities.AggregateModels.Personals.PersonalDTOs;

public sealed record PersonalUpdateDTO
{
    public string PhoneNumber { get; set; } = null!;
    public string Address { get; set; } = default!;
    public string PicturePath { get; set; } = null!;
}
