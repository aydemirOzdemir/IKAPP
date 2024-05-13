using AutoMapper;
using IKAPP.Application.Bases;
using IKAPP.Application.Contract.DepartmentRepositories;
using IKAPP.Application.Contract.UnitOfWork;
using IKAPP.Application.Features.DepartmentFeatures.DepartmentRules;
using IKAPP.Domain.Entities.AggregateModels.Departments;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace IKAPP.Application.Features.DepartmentFeatures.DepartmentCommands.DepartmentDelete;

public class DepatmentDeleteCommandHandler : BaseHandler<IDepartmentReadRepository, IDepartmentWriteRepository>,IRequestHandler<DepatmentDeleteCommand, IResult>
{
    private readonly DepartmentRuleForApplication rules;

    public DepatmentDeleteCommandHandler(IMapper mapper, IUnitOfWork<IDepartmentReadRepository, IDepartmentWriteRepository> unitOfWork, IHttpContextAccessor httpContextAccessor,DepartmentRuleForApplication rules) : base(mapper, unitOfWork, httpContextAccessor)
    {
        this.rules = rules;
    }

    public async Task<IResult> Handle(DepatmentDeleteCommand request, CancellationToken cancellationToken)
    {
        Department? department = await unitOfWork.ReadRepository.GetByIdAsync(request.Id);
        await rules.DepartmentShouldNotBeNull(department,"Silinecek öğe bulunamadı.");
         await unitOfWork.WriteRepository.DeleteAsync(department!);
        await unitOfWork.SaveAsync();
        return Result.Response(System.Net.HttpStatusCode.OK,"Öğe silindi.");
    }
}
