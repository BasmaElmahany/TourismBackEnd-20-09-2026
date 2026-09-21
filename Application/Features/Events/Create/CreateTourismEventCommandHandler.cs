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
using Tourism.Application.Interfaces;
using Tourism.Application.IUnitofwork;
using Tourism.Domain.Entities;
using Tourism.Domain.Entities.Common;

namespace Tourism.Application.Features.Events.Create
{
    public class CreateTourismEventCommandHandler
        : IRequestHandler<CreateTourismEventCommand, ApiResponse<TourismEventDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileStorageService _fileStorage;

        public CreateTourismEventCommandHandler(
            IUnitOfWork unitOfWork,
            IFileStorageService fileStorage)
        {
            _unitOfWork = unitOfWork;
            _fileStorage = fileStorage;
        }

        public async Task<ApiResponse<TourismEventDto>> Handle(
            CreateTourismEventCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. حفظ الصورة عبر خدمة الملفات داخل مجلد events
                string imagePath = request.ImageUrl ?? string.Empty;
                if (request.ImageFile != null && request.ImageFile.Length > 0)
                {
                    imagePath = await _fileStorage.SaveFileAsync(request.ImageFile, "events", cancellationToken);
                }

                LocalizedText MapLocalized(LocalizedTextDto? dto) =>
                    new LocalizedText
                    {
                        En = dto?.En ?? string.Empty,
                        Ar = dto?.Ar ?? string.Empty
                    };

                var entity = new TourismEvent
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = MapLocalized(request.Name),
                    Description = MapLocalized(request.Description),
                    ImageUrl = imagePath,
                    StartDate = request.StartDate,
                    EndDate = request.EndDate,
                    Location = MapLocalized(request.Location),
                    Latitude = request.Latitude,
                    Longitude = request.Longitude,
                    TicketPrice = request.TicketPrice != null ? MapLocalized(request.TicketPrice) : null,
                    IsFree = request.IsFree,
                    Category = MapLocalized(request.Category),
                    Organizer = request.Organizer != null ? MapLocalized(request.Organizer) : null,
                    ContactInfo = request.ContactInfo != null ? new EventContactInfo
                    {
                        Phone = request.ContactInfo.Phone,
                        Email = request.ContactInfo.Email,
                        Website = request.ContactInfo.Website
                    } : null
                };

                await _unitOfWork.Events.AddAsync(entity, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                var dto = new TourismEventDto
                {
                    Id = entity.Id,
                    Name = request.Name,
                    Description = request.Description,
                    ImageUrl = entity.ImageUrl,
                    StartDate = entity.StartDate,
                    EndDate = entity.EndDate,
                    Location = request.Location,
                    Latitude = entity.Latitude,
                    Longitude = entity.Longitude,
                    TicketPrice = request.TicketPrice,
                    IsFree = entity.IsFree,
                    Category = request.Category,
                    Organizer = request.Organizer,
                    ContactInfo = request.ContactInfo
                };

                return new ApiResponse<TourismEventDto>
                {
                    Success = true,
                    Data = dto,
                    Message = "تم إضافة الفعالية بنجاح",
                    Code = StatusCodes.Status201Created
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<TourismEventDto>
                {
                    Success = false,
                    Data = null!,
                    Message = $"حدث خطأ أثناء إضافة الفعالية: {ex.InnerException?.Message ?? ex.Message}",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}