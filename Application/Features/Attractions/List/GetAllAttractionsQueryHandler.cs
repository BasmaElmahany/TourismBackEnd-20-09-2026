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

namespace Tourism.Application.Features.Attractions.List
{
    public class GetAllAttractionsQueryHandler
         : IRequestHandler<GetAllAttractionsQuery, ApiResponse<List<AttractionDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllAttractionsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<List<AttractionDto>>> Handle(
            GetAllAttractionsQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                var attractions = await _unitOfWork.Attractions.GetAllAsync(cancellationToken);

                var dtos = attractions.Select(x => new AttractionDto
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
                }).ToList();

                return new ApiResponse<List<AttractionDto>>
                {
                    Success = true,
                    Data = dtos,
                    Message = "تم جلب المعالم السياحية بنجاح",
                    Code = StatusCodes.Status200OK
                };
            }
            catch
            {
                return new ApiResponse<List<AttractionDto>>
                {
                    Success = false,
                    Data = null,
                    Message = "حدث خطأ أثناء جلب المعالم السياحية",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}
