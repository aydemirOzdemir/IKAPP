using AutoMapper;
using IKAPP.Application.Bases;
using IKAPP.Application.Contract.AdvanceRepositories;
using IKAPP.Application.Contract.UnitOfWork;
using IKAPP.Application.Dtos.AdvanceDTOs;
using IKAPP.Domain.Entities.AggregateModels.Advances;
using IKAPP.Domain.Ultities.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace IKAPP.Application.Features.AdvanceFeatures.AdvanceQueries.AdvanceGetForEdit;

public class AdvanceGetForEditQueryHandler : BaseHandler<IAdvanceReadRepository, IAdvanceWriteRepository>,IRequestHandler<AdvanceGetForEditQuery, IDataResult<AdvanceUpdateViewDTO>>
{
    public AdvanceGetForEditQueryHandler(IMapper mapper, IUnitOfWork<IAdvanceReadRepository, IAdvanceWriteRepository> unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
    {
    }

    public async Task<IDataResult<AdvanceUpdateViewDTO>> Handle(AdvanceGetForEditQuery request, CancellationToken cancellationToken)  =>  DataResult<AdvanceUpdateViewDTO>.DataResponse(mapper.Map<AdvanceUpdateViewDTO>(await unitOfWork.ReadRepository.GetByIdAsync(request.Id,request.IsTracking)),System.Net.HttpStatusCode.OK,"Güncellenecek data getirildi.");
    
}
