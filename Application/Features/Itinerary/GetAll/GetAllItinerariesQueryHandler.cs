using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Application.Common.DTOs;
using Tourism.Application.Features.Authentication.DTOs;
using Tourism.Application.Features.DTOs;
using Tourism.Application.IUnitofwork;
using Tourism.Domain.Entities.Common;

namespace Tourism.Application.Features.Itinerary.GetAll
{
    public class GetAllItinerariesQueryHandler
           : IRequestHandler<GetAllItinerariesQuery, ApiResponse<List<ItineraryDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllItinerariesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<List<ItineraryDto>>> Handle(
            GetAllItinerariesQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // جلب جميع البرامج متضمنة تفاصيل الأيام
                var itineraries = await _unitOfWork.Itineraries.GetAllAsync(cancellationToken);

                LocalizedTextDto MapLocalized(LocalizedText? entity) =>
                    new LocalizedTextDto
                    {
                        En = entity?.En ?? string.Empty,
                        Ar = entity?.Ar ?? string.Empty
                    };

                List<LocalizedTextDto> MapLocalizedList(List<LocalizedText>? list) =>
                    list?.Select(MapLocalized).ToList() ?? new List<LocalizedTextDto>();

                var dtos = itineraries.Select(item => new ItineraryDto
                {
                    Id = item.Id,
                    Title = MapLocalized(item.Title),
                    Description = MapLocalized(item.Description),
                    Duration = MapLocalized(item.Duration),
                    Difficulty = MapLocalized(item.Difficulty),
                    Price = MapLocalized(item.Price),
                    Image = item.Image ?? string.Empty,
                    Highlights = MapLocalizedList(item.Highlights),
                    Includes = MapLocalizedList(item.Includes),
                    Excludes = MapLocalizedList(item.Excludes),
                    BestTime = item.BestTime != null ? MapLocalized(item.BestTime) : null,
                    GroupSize = item.GroupSize != null ? MapLocalized(item.GroupSize) : null,
                    IsFeatured = item.IsFeatured ?? false,
                    Category = MapLocalized(item.Category),
                    DayByDay = item.DayByDay?.Select(d => new ItineraryDayDto
                    {
                        Id = d.Id,
                        Day = d.Day ?? 0,
                        Title = MapLocalized(d.Title),
                        Description = MapLocalized(d.Description),
                        Activities = MapLocalizedList(d.Activities),
                        Meals = MapLocalizedList(d.Meals),
                        Accommodation = d.Accommodation != null ? MapLocalized(d.Accommodation) : null
                    }).ToList()
                }).ToList();

                return new ApiResponse<List<ItineraryDto>>
                {
                    Success = true,
                    Data = dtos,
                    Message = "تم جلب جميع برامج الرحلات بنجاح",
                    Code = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<ItineraryDto>>
                {
                    Success = false,
                    Data = new List<ItineraryDto>(),
                    Message = $"حدث خطأ أثناء جلب البرامج: {ex.InnerException?.Message ?? ex.Message}",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}