using MediatR;
using Microsoft.AspNetCore.Http;
using Tourism.Application.Common.DTOs;
using Tourism.Application.Features.Authentication.DTOs;

namespace Tourism.Application.Features.Photographers.Create
{
    public record CreatePhotographerCommand(
         LocalizedTextDto Name,
         LocalizedTextDto? Bio,
         List<object>? Specialties,
         IFormFile? ImageFile,
         LocalizedTextDto? Phone,
         LocalizedTextDto? Email,
         SocialLinksDto? Social,
         LocationInfoDto? Location,
         double? Rating
     ) : IRequest<ApiResponse<PhotographerDto>>;
}