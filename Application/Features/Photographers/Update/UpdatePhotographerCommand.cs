using MediatR;
using Microsoft.AspNetCore.Http;
using Tourism.Application.Common.DTOs;
using Tourism.Application.Features.Authentication.DTOs;

namespace Tourism.Application.Features.Photographers.Update
{
    public record UpdatePhotographerCommand(
         string Id,
         LocalizedTextDto Name,
         LocalizedTextDto? Bio,
         List<object>? Specialties,
         IFormFile? ImageFile,                     // Optional: upload a new image
         string? ExistingImageUrl,                 // Keeps the current image if no new file is uploaded
         LocalizedTextDto? Phone,
         LocalizedTextDto? Email,
         SocialLinksDto? Social,
         LocationInfoDto? Location,
         double? Rating
     ) : IRequest<ApiResponse<bool>>;
}