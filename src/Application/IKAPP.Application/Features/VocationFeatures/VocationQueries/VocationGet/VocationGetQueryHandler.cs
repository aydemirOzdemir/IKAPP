using AutoMapper;
using IKAPP.Application.Bases;
using IKAPP.Application.Contract.UnitOfWork;
using IKAPP.Application.Contract.VocationRepositories;
using IKAPP.Application.Dtos.TypeOfPermissionDTOs;
using IKAPP.Application.Dtos.VocationDTOs;
using IKAPP.Domain.Entities.AggregateModels.TypeofPermissions;
using IKAPP.Domain.Entities.AggregateModels.Vocations;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace IKAPP.Application.Features.VocationFeatures.VocationQueries.VocationGet;

public class VocationGetQueryHandler : BaseHandler<IVocationReadRepository, IVocationWriteRepository>,IRequestHandler<VocationGetQuery, IDataResult<VocationViewDTO>>
{
    public VocationGetQueryHandler(IMapper mapper, IUnitOfWork<IVocationReadRepository, IVocationWriteRepository> unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
    {
    }

    public async Task<IDataResult<VocationViewDTO>> Handle(VocationGetQuery request, CancellationToken cancellationToken)
    {
        Vocation? vocation = await unitOfWork.ReadRepository.GetByIdAsync(request.Id);

        return DataResult<VocationViewDTO>.DataResponse(mapper.Map<VocationViewDTO>(vocation!.CreateVocationDTO()), System.Net.HttpStatusCode.OK, "Meslek gönderildi.");
    }
}
