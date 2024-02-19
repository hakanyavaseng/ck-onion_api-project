using Microsoft.AspNetCore.Http;
using OnionAPI.Application.Interfaces.AutoMapper;
using OnionAPI.Application.Interfaces.UnitOfWorks;
using OnionAPI.Domain.Entities.Identity;
using System.Security.Claims;

namespace OnionAPI.Application.Bases
{
    public class BaseHandler
    {
        protected readonly IMapper mapper;
        protected readonly IUnitOfWork unitOfWork;
        protected readonly IHttpContextAccessor httpContextAccessor;
        protected readonly string userId;

        public BaseHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.httpContextAccessor = httpContextAccessor;
            userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

    }
}
