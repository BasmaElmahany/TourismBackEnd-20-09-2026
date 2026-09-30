using MediatR;
using Microsoft.AspNetCore.Http;
using Tourism.Application.Common.DTOs;

public record UpdateSouvenirShopCommand(
     string Id,
     string Name,
     string NameAr,
     string? Description,
     string? DescriptionAr,
     string? Category,
     string? CategoryAr,
     string? Address,
     string? AddressAr,
     string? Phone,
     string? Email,
     IFormFile? ImageFile,
     string? ExistingImage,
     List<IFormFile>? NewImagesFiles,
     List<string>? ExistingImages,
     double? Latitude,
     double? Longitude,
     double? DistanceKm,
     double? Rating,
     int? ReviewCount,
     string? PriceRange,
     string? OpeningHours,
     string? OpeningHoursAr,
     bool? IsFeatured,
     bool? AcceptsCreditCard,
     bool? HasDelivery,
     bool? HasOnlineStore,
     List<string>? Specialties,
     List<string>? SpecialtiesAr
 ) : IRequest<ApiResponse<bool>>;