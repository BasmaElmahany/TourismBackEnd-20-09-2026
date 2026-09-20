using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Application.Common.DTOs;
using Tourism.Application.IUnitofwork;
using Tourism.Domain.Entities.Common;
using Tourism.Domain.Entities;

namespace Tourism.Application.Features.Attractions.BulkCreate
{
    public class BulkCreateAttractionsCommandHandler
         : IRequestHandler<BulkCreateAttractionsCommand, ApiResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BulkCreateAttractionsCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<int>> Handle(
            BulkCreateAttractionsCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                if (request.Attractions == null || !request.Attractions.Any())
                {
                    return new ApiResponse<int>
                    {
                        Success = false,
                        Data = 0,
                        Message = "قائمة المعالم السياحية فارغة",
                        Code = StatusCodes.Status400BadRequest
                    };
                }

                var entities = request.Attractions.Select(item => new Attraction
                {
                    Id = string.IsNullOrWhiteSpace(item.Id) ? Guid.NewGuid().ToString() : item.Id,
                    Name = new LocalizedText { En = item.Name.En, Ar = item.Name.Ar },
                    Description = new LocalizedText { En = item.Description.En, Ar = item.Description.Ar },
                    ImageUrl = item.ImageUrl,
                    ImageGallery = item.ImageGallery ?? new List<string>(),
                    Latitude = item.Latitude,
                    Longitude = item.Longitude,
                    OpeningHours = new LocalizedText { En = item.OpeningHours.En, Ar = item.OpeningHours.Ar },
                    TicketPrice = new LocalizedText { En = item.TicketPrice.En, Ar = item.TicketPrice.Ar },
                    BookingUrl = item.BookingUrl,
                    Rating = item.Rating,
                    ReviewCount = item.ReviewCount,
                    Category = new LocalizedText { En = item.Category.En, Ar = item.Category.Ar },
                    Features = item.Features?.Select(f => new LocalizedText { En = f.En, Ar = f.Ar }).ToList() ?? new List<LocalizedText>(),
                    HistoricalPeriod = item.HistoricalPeriod is null ? null : new LocalizedText { En = item.HistoricalPeriod.En, Ar = item.HistoricalPeriod.Ar },
                    Significance = item.Significance is null ? null : new LocalizedText { En = item.Significance.En, Ar = item.Significance.Ar }
                }).ToList();

                foreach (var entity in entities)
                {
                    await _unitOfWork.Attractions.AddAsync(entity, cancellationToken);
                }

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new ApiResponse<int>
                {
                    Success = true,
                    Data = entities.Count,
                    Message = $"تم إدخال {entities.Count} معلماً سياحياً بنجاح",
                    Code = StatusCodes.Status201Created
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>
                {
                    Success = false,
                    Data = 0,
                    Message = $"حدث خطأ أثناء الإدخال الجماعي: {ex.Message}",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}