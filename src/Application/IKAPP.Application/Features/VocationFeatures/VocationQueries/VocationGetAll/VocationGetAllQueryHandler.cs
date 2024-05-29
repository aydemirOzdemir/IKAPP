using AutoMapper;
using IKAPP.Application.Bases;
using IKAPP.Application.Contract.UnitOfWork;
using IKAPP.Application.Contract.VocationRepositories;
using IKAPP.Application.Dtos.DepartmentDTOs;
using IKAPP.Application.Dtos.VocationDTOs;
using IKAPP.Domain.Entities.AggregateModels.Departments;
using IKAPP.Domain.Entities.AggregateModels.Vocations;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace IKAPP.Application.Features.VocationFeatures.VocationQueries.VocationGetAll;

public class VocationGetAllQueryHandler : BaseHandler<IVocationReadRepository, IVocationWriteRepository>,IRequestHandler<VocationGetAllQuery, IDataResult<IEnumerable<VocationViewDTO>>>
{
    public VocationGetAllQueryHandler(IMapper mapper, IUnitOfWork<IVocationReadRepository, IVocationWriteRepository> unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
    {
    }

    public async Task<IDataResult<IEnumerable<VocationViewDTO>>> Handle(VocationGetAllQuery request, CancellationToken cancellationToken)
    {
        return DataResult<IEnumerable<VocationViewDTO>>.DataResponse(mapper.Map<IEnumerable<VocationViewDTO>>(Vocation.CreateVocationDTOs(await unitOfWork.ReadRepository.GetAllAsync(tracking: request.Tracking))), System.Net.HttpStatusCode.OK, "Meslekler listelendi.");

    }
}
