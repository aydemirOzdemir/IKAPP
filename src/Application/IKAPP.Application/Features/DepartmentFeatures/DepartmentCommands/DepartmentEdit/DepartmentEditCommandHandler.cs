using AutoMapper;
using IKAPP.Application.Bases;
using IKAPP.Application.Contract.DepartmentRepositories;
using IKAPP.Application.Contract.UnitOfWork;
using IKAPP.Application.Features.DepartmentFeatures.DepartmentRules;
using IKAPP.Domain.Entities.AggregateModels.Departments;
using IKAPP.Domain.Entities.AggregateModels.Departments.DepartmentDTOs;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace IKAPP.Application.Features.DepartmentFeatures.DepartmentCommands.DepartmentEdit;

public class DepartmentEditCommandHandler : BaseHandler<IDepartmentReadRepository, IDepartmentWriteRepository>,IRequestHandler<DepartmentEditCommand,IResult>
{
    private readonly DepartmentRuleForApplication rules;

    public DepartmentEditCommandHandler(IMapper mapper, IUnitOfWork<IDepartmentReadRepository, IDepartmentWriteRepository> unitOfWork, IHttpContextAccessor httpContextAccessor,DepartmentRuleForApplication
       rules) : base(mapper, unitOfWork, httpContextAccessor)
    {
        this.rules = rules;
    }

    public async Task<IResult> Handle(DepartmentEditCommand request, CancellationToken cancellationToken)
    {
        Department? department = await unitOfWork.ReadRepository.GetByIdAsync(request.Id);

        await rules.DepartmentShouldNotBeNull(department,"Güncellenecek Öğe Bulunamadı.");
        await department!.UpdateDepartment(mapper.Map<DepartmentUpdateDTO>(request));
        Department result = await unitOfWork.WriteRepository.UpdateAsync(department);
        await rules.DepartmentShouldNotBeNull(department, "Güncelleme işlemi başarısız.");
        await unitOfWork.SaveAsync();
        return Result.Response(System.Net.HttpStatusCode.OK,"Güncelleme işlemi başarıyla tamamlandı.");
       
    }
}
