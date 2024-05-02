using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Dtos.PersonalDTOs;

public class PersonalInformationForEditDTO
{
    public string PhoneNumber { get; set; }
    public string Address { get; set; } = default!;
    public string? PicturePath { get; set; }
    public IFormFile? Picture { get; set; }
}
