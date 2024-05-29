using AutoMapper;
using IKAPP.Application.Bases;
using IKAPP.Application.Contract.DepartmentRepositories;
using IKAPP.Application.Contract.UnitOfWork;
using IKAPP.Application.Features.DepartmentFeatures.DepartmentRules;
using IKAPP.Domain.Entities.AggregateModels.Departments;
using IKAPP.Domain.Entities.AggregateModels.Departments.DepartmentDTOs;
using IKAPP.Domain.Entities.AggregateModels.Personals;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace IKAPP.Application.Features.DepartmentFeatures.DepartmentCommands.DepartmentCreate;

public class DepartmentCreateCommandHandler : BaseHandler<IDepartmentReadRepository, IDepartmentWriteRepository>, IRequestHandler<DepartmentCreateCommand, IResult>
{
    private readonly DepartmentRuleForApplication rules;
    private readonly UserManager<Personal> userManager;

    public DepartmentCreateCommandHandler(IMapper mapper, IUnitOfWork<IDepartmentReadRepository, IDepartmentWriteRepository> unitOfWork, IHttpContextAccessor httpContextAccessor, DepartmentRuleForApplication rules, UserManager<Personal> userManager) : base(mapper, unitOfWork, httpContextAccessor)
    {
        this.rules = rules;
        this.userManager = userManager;
    }

    public async Task<IResult> Handle(DepartmentCreateCommand request, CancellationToken cancellationToken)
    {
        DepartmentDTO departmentDTO = mapper.Map<DepartmentDTO>(request);
        departmentDTO.Id=Guid.NewGuid().ToString();

        Personal? personal = await userManager.FindByIdAsync(userId);
        Department department = Department.CreateDepartment(departmentDTO);
        await rules.DepartmentShouldNotBeNull(department, "Department oluşturulamadı");
        

     await department.AddCompanies(new List<DepartmentCompany> {DepartmentCompany.CreateDepartmentCompany(new()
        {
            DepartmanId = department.Id,
            Department = department,
            Company = personal.Company,
            CompanyId = personal.CompanyId
        })});

        Department result=await unitOfWork.WriteRepository.AddAsync(department);
        await rules.DepartmentShouldNotBeNull(result, "Department oluşturulamadı");
        await unitOfWork.SaveAsync();
        return Result.Response(System.Net.HttpStatusCode.Created,"Departman oluşturuldu.");

    }
}
