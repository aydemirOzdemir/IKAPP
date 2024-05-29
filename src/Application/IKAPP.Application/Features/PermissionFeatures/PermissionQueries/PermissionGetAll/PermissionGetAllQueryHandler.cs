using AutoMapper;
using IKAPP.Application.Bases;
using IKAPP.Application.Contract.PermissionRepositories;
using IKAPP.Application.Contract.UnitOfWork;
using IKAPP.Application.Dtos.ExpenseDTOs;
using IKAPP.Application.Dtos.PermissionDTOs;
using IKAPP.Application.Features.PermissionFeatures.PermissionRules;
using IKAPP.Domain.Entities.AggregateModels.Expenses;
using IKAPP.Domain.Entities.AggregateModels.Permissions;
using IKAPP.Domain.Entities.AggregateModels.Personals;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IKAPP.Application.Features.PermissionFeatures.PermissionQueries.PermissionGetAll;

public class PermissionGetAllQueryHandler : BaseHandler<IPermissionReadRepository, IPermissionWriteRepository>, IRequestHandler<PermissionGetAllQuery, IDataResult<IEnumerable<PermissionViewDTO>>>
{
    private readonly UserManager<Personal> userManager;
    private readonly PermissionRuleForApplication rules;

    public PermissionGetAllQueryHandler(IMapper mapper, IUnitOfWork<IPermissionReadRepository, IPermissionWriteRepository> unitOfWork, IHttpContextAccessor httpContextAccessor,UserManager<Personal> userManager,PermissionRuleForApplication rules) : base(mapper, unitOfWork, httpContextAccessor)
    {
        this.userManager = userManager;
        this.rules = rules;
    }

    public async Task<IDataResult<IEnumerable<PermissionViewDTO>>> Handle(PermissionGetAllQuery request, CancellationToken cancellationToken)
    {
        Personal? personal = await userManager.FindByIdAsync(userId);
        if (request.IsApproval)
            return DataResult<IEnumerable<PermissionViewDTO>>.DataResponse(mapper.Map<IEnumerable<PermissionViewDTO>>(Permission.CreatePermissionDTOs(await unitOfWork.ReadRepository.GetAllAsync(f => f.CompanyId == personal.CompanyId, include: query => query.Include(p => p.Personal)))), System.Net.HttpStatusCode.OK, "İzinler getirildi");

        return DataResult<IEnumerable<PermissionViewDTO>>.DataResponse(mapper.Map<IEnumerable<PermissionViewDTO>>(Permission.CreatePermissionDTOs(await unitOfWork.ReadRepository.GetAllAsync(f => f.PersonalId == personal.Id, tracking: request.Tracking))), System.Net.HttpStatusCode.OK, "İzinler getirildi");
    }
}
