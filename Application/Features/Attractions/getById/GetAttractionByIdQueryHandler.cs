using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Application.Common.DTOs;
using Tourism.Application.Features.Authentication.DTOs;
using Tourism.Application.IUnitofwork;

namespace Tourism.Application.Features.Attractions.getById
{
    public class GetAttractionByIdQueryHandler
         : IRequestHandler<GetAttractionByIdQuery, ApiResponse<AttractionDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAttractionByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<AttractionDto>> Handle(
            GetAttractionByIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                var x = await _unitOfWork.Attractions.GetByIdAsync(request.Id, cancellationToken);

                if (x is null)
                {
                    return new ApiResponse<AttractionDto>
                    {
                        Success = false,
                        Data = null,
                        Message = "المعلم السياحي غير موجود",
                        Code = StatusCodes.Status404NotFound
                    };
                }

                var dto = new AttractionDto
                {
                    Id = x.Id,
                    Name = new LocalizedTextDto { En = x.Name.En, Ar = x.Name.Ar },
                    Description = new LocalizedTextDto { En = x.Description.En, Ar = x.Description.Ar },
                    ImageUrl = x.ImageUrl,
                    ImageGallery = x.ImageGallery,
                    Latitude = x.Latitude,
                    Longitude = x.Longitude,
                    OpeningHours = new LocalizedTextDto { En = x.OpeningHours.En, Ar = x.OpeningHours.Ar },
                    TicketPrice = new LocalizedTextDto { En = x.TicketPrice.En, Ar = x.TicketPrice.Ar },
                    BookingUrl = x.BookingUrl,
                    Rating = x.Rating,
                    ReviewCount = x.ReviewCount,
                    Category = new LocalizedTextDto { En = x.Category.En, Ar = x.Category.Ar },
                    Features = x.Features.Select(f => new LocalizedTextDto { En = f.En, Ar = f.Ar }).ToList(),
                    HistoricalPeriod = x.HistoricalPeriod is null ? null : new LocalizedTextDto { En = x.HistoricalPeriod.En, Ar = x.HistoricalPeriod.Ar },
                    Significance = x.Significance is null ? null : new LocalizedTextDto { En = x.Significance.En, Ar = x.Significance.Ar }
                };

                return new ApiResponse<AttractionDto>
                {
                    Success = true,
                    Data = dto,
                    Message = "تم جلب بيانات المعلم السياحي بنجاح",
                    Code = StatusCodes.Status200OK
                };
            }
            catch
            {
                return new ApiResponse<AttractionDto>
                {
                    Success = false,
                    Data = null,
                    Message = "حدث خطأ غير متوقع",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}
