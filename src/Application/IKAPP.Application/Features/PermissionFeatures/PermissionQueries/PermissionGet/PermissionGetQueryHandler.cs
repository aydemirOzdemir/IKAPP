using AutoMapper;
using IKAPP.Application.Bases;
using IKAPP.Application.Contract.PermissionRepositories;
using IKAPP.Application.Contract.UnitOfWork;
using IKAPP.Application.Dtos.ExpenseDTOs;
using IKAPP.Application.Dtos.PermissionDTOs;
using IKAPP.Application.Features.PermissionFeatures.PermissionRules;
using IKAPP.Domain.Entities.AggregateModels.Expenses;
using IKAPP.Domain.Entities.AggregateModels.Permissions;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace IKAPP.Application.Features.PermissionFeatures.PermissionQueries.PermissionGet;

public class PermissionGetQueryHandler : BaseHandler<IPermissionReadRepository, IPermissionWriteRepository>,IRequestHandler<PermissionGetQuery,IDataResult<PermissionViewDTO>>
{
    private readonly PermissionRuleForApplication rules;

    public PermissionGetQueryHandler(IMapper mapper, IUnitOfWork<IPermissionReadRepository, IPermissionWriteRepository> unitOfWork, IHttpContextAccessor httpContextAccessor,PermissionRuleForApplication rules) : base(mapper, unitOfWork, httpContextAccessor)
    {
        this.rules = rules;
    }

    public async Task<IDataResult<PermissionViewDTO>> Handle(PermissionGetQuery request, CancellationToken cancellationToken)
    {
        if (request.IsApproval)
        {
            Permission? permissionApproval = await unitOfWork.ReadRepository.GetAsync(x => x.Id == request.Id, include: query => query.Include(p => p.Personal));
            await rules.PermissionShouldNotBeNull(permissionApproval, "Öğe bulunamadı.");
            return DataResult<PermissionViewDTO>.DataResponse(mapper.Map<PermissionViewDTO>(permissionApproval.CreatePermissionDTO()), System.Net.HttpStatusCode.OK, "Harcama Gönderildi");
        }
        Permission? permission = await unitOfWork.ReadRepository.GetByIdAsync(request.Id);
        await rules.PermissionShouldNotBeNull(permission, "Öğe bulunamadı.");
        return DataResult<PermissionViewDTO>.DataResponse(mapper.Map<PermissionViewDTO>(permission!.CreatePermissionDTO()), System.Net.HttpStatusCode.OK, "İzin gönderildi.");
       
    }
}