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

namespace Tourism.Application.Features.Events.GetAll
{
    public class GetAllTourismEventsQueryHandler
         : IRequestHandler<GetAllTourismEventsQuery, ApiResponse<List<TourismEventDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllTourismEventsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<List<TourismEventDto>>> Handle(
            GetAllTourismEventsQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                var events = await _unitOfWork.Events.GetAllAsync(cancellationToken);

                LocalizedTextDto MapLocalized(LocalizedText? entity) =>
                    new LocalizedTextDto
                    {
                        En = entity?.En ?? string.Empty,
                        Ar = entity?.Ar ?? string.Empty
                    };

                var dtos = events.Select(e => new TourismEventDto
                {
                    Id = e.Id,
                    Name = MapLocalized(e.Name),
                    Description = MapLocalized(e.Description),
                    ImageUrl = e.ImageUrl ?? string.Empty,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate,
                    Location = MapLocalized(e.Location),
                    Latitude = e.Latitude,
                    Longitude = e.Longitude,
                    TicketPrice = e.TicketPrice != null ? MapLocalized(e.TicketPrice) : null,
                    IsFree = e.IsFree,
                    Category = MapLocalized(e.Category),
                    Organizer = e.Organizer != null ? MapLocalized(e.Organizer) : null,
                    ContactInfo = e.ContactInfo != null ? new EventContactInfoDto
                    {
                        Phone = e.ContactInfo.Phone,
                        Email = e.ContactInfo.Email,
                        Website = e.ContactInfo.Website
                    } : null
                }).ToList();

                return new ApiResponse<List<TourismEventDto>>
                {
                    Success = true,
                    Data = dtos,
                    Message = "تم جلب الفعاليات بنجاح",
                    Code = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<TourismEventDto>>
                {
                    Success = false,
                    Data = new List<TourismEventDto>(),
                    Message = $"حدث خطأ أثناء جلب الفعاليات: {ex.InnerException?.Message ?? ex.Message}",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}