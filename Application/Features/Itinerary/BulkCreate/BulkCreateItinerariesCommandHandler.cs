using MediatR;
using Microsoft.AspNetCore.Http;
using Tourism.Application.Common.DTOs;
using Tourism.Application.Features.Authentication.DTOs;
using Tourism.Application.IUnitofwork;
using Tourism.Domain.Entities;
using Tourism.Domain.Entities.Common;

namespace Tourism.Application.Features.Itinerary.BulkCreate
{
    public class BulkCreateItinerariesCommandHandler
         : IRequestHandler<BulkCreateItinerariesCommand, ApiResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BulkCreateItinerariesCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<int>> Handle(
            BulkCreateItinerariesCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                if (request.Itineraries == null || !request.Itineraries.Any())
                {
                    return new ApiResponse<int>
                    {
                        Success = false,
                        Data = 0,
                        Message = "قائمة البرامج السياحية فارغة",
                        Code = StatusCodes.Status400BadRequest
                    };
                }

                LocalizedText MapLocalized(LocalizedTextDto? dto) =>
                    new LocalizedText
                    {
                        En = dto?.En ?? string.Empty,
                        Ar = dto?.Ar ?? string.Empty
                    };

                List<LocalizedText> MapLocalizedList(List<LocalizedTextDto>? list) =>
                    list?.Select(MapLocalized).ToList() ?? new List<LocalizedText>();

                var entities = request.Itineraries.Select(dto => new Tourism.Domain.Entities.Itinerary
                {
                    Id = string.IsNullOrWhiteSpace(dto.Id) ? Guid.NewGuid().ToString() : dto.Id,
                    Title = MapLocalized(dto.Title),
                    Description = MapLocalized(dto.Description),
                    Duration = MapLocalized(dto.Duration),
                    Difficulty = MapLocalized(dto.Difficulty),
                    Price = MapLocalized(dto.Price),
                    Image = dto.Image ?? string.Empty,
                    Highlights = MapLocalizedList(dto.Highlights),
                    Includes = MapLocalizedList(dto.Includes),
                    Excludes = MapLocalizedList(dto.Excludes),
                    BestTime = dto.BestTime != null ? MapLocalized(dto.BestTime) : null,
                    GroupSize = dto.GroupSize != null ? MapLocalized(dto.GroupSize) : null,
                    IsFeatured = dto.IsFeatured,
                    Category = MapLocalized(dto.Category),
                    DayByDay = dto.DayByDay?.Select(d => new ItineraryDay
                    {
                        Day = d.Day,
                        Title = MapLocalized(d.Title),
                        Description = MapLocalized(d.Description),
                        Activities = MapLocalizedList(d.Activities),
                        Meals = MapLocalizedList(d.Meals),
                        Accommodation = d.Accommodation != null ? MapLocalized(d.Accommodation) : null
                    }).ToList() ?? new List<ItineraryDay>()
                }).ToList();

                foreach (var entity in entities)
                {
                    await _unitOfWork.Itineraries.AddAsync(entity, cancellationToken);
                }

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new ApiResponse<int>
                {
                    Success = true,
                    Data = entities.Count,
                    Message = $"تم إضافة {entities.Count} برنامج سياحي بنجاح",
                    Code = StatusCodes.Status201Created
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>
                {
                    Success = false,
                    Data = 0,
                    Message = $"حدث خطأ أثناء الإدخال الجماعي: {ex.InnerException?.Message ?? ex.Message}",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}