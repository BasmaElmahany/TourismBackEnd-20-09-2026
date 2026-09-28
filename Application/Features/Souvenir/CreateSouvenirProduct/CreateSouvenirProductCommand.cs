using MediatR;
using Tourism.Application.Common.DTOs;
using Tourism.Application.Features.Authentication.DTOs;

namespace Tourism.Application.Features.Souvenir.CreateSouvenirProduct
{
    public record CreateSouvenirProductCommand(
        string ShopId,
        string Name,
        string NameAr,
        string Description,
        string DescriptionAr,
        string Category,
        string CategoryAr,
        decimal Price,
        string Currency,
        string Image,
        List<string>? Images,
        bool InStock,
        bool? Handmade,
        string? Material,
        string? MaterialAr,
        string? Origin,
        string? OriginAr
    ) : IRequest<ApiResponse<SouvenirProductDto>>;
}
