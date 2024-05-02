using IKAPP.Application.Dtos.CompanyDTOs;
using IKAPP.Application.Dtos.DepartmentDTOs;
using IKAPP.Application.Dtos.VocationDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Dtos.PersonalDTOs;

public class PersonalDepartmentVocationCompany
{
   // public PersonelCreateCommand personelCreateCommand { get; set; }

    public IEnumerable<CompanyViewDTO> companyViewModel { get; set; }
    public IEnumerable<DepartmentViewDTO> departmentViewModels { get; set; }

    public IEnumerable<VocationViewDTO> vocationViewModels { get; set; }
}
