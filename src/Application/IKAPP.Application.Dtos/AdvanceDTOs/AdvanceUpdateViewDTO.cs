using IKAPP.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Dtos.AdvanceDTOs;

public class AdvanceUpdateViewDTO
{
    public string Id { get; set; }

    public decimal TotalAmount { get; set; }
    public Currency Currency { get; set; }
    public TypeofAdvance TypeofAdvance { get; set; }
    public string Description { get; set; }
}
