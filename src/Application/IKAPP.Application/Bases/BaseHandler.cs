using AutoMapper;
using IKAPP.Application.Contract.UnitOfWork;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.Application.Bases;

public class BaseHandler<TReadRepository,TWriteRepository>
{
    public readonly IMapper mapper;
    public readonly IUnitOfWork<TReadRepository, TWriteRepository> unitOfWork;
    public readonly IHttpContextAccessor httpContextAccessor;
    public readonly string userId;

    public BaseHandler(IMapper mapper, IUnitOfWork<TReadRepository, TWriteRepository> unitOfWork, IHttpContextAccessor httpContextAccessor)
    {
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
        this.httpContextAccessor = httpContextAccessor;
        userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
