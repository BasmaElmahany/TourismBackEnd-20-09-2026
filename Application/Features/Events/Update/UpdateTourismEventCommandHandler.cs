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
using Tourism.Domain.Entities.Common;
using Tourism.Domain.Entities;

namespace Tourism.Application.Features.Events.Update
{
    public class UpdateTourismEventCommandHandler
         : IRequestHandler<UpdateTourismEventCommand, ApiResponse<TourismEventDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileStorageService _fileStorage;

        public UpdateTourismEventCommandHandler(
            IUnitOfWork unitOfWork,
            IFileStorageService fileStorage)
        {
            _unitOfWork = unitOfWork;
            _fileStorage = fileStorage;
        }

        public async Task<ApiResponse<TourismEventDto>> Handle(
            UpdateTourismEventCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _unitOfWork.Events.GetByIdAsync(request.Id, cancellationToken);
                if (entity == null)
                {
                    return new ApiResponse<TourismEventDto>
                    {
                        Success = false,
                        Data = null!,
                        Message = "الفعالية غير موجودة",
                        Code = StatusCodes.Status404NotFound
                    };
                }

                // إدارة الصورة (حفظ الجديدة وحذف القديمة إن وجدت)
                if (request.ImageFile != null && request.ImageFile.Length > 0)
                {
                    if (!string.IsNullOrEmpty(entity.ImageUrl))
                    {
                        _fileStorage.DeleteFile(entity.ImageUrl);
                    }
                    entity.ImageUrl = await _fileStorage.SaveFileAsync(request.ImageFile, "events", cancellationToken);
                }
                else if (!string.IsNullOrEmpty(request.ImageUrl))
                {
                    entity.ImageUrl = request.ImageUrl;
                }

                LocalizedText MapLocalized(LocalizedTextDto? dto) =>
                    new LocalizedText
                    {
                        En = dto?.En ?? string.Empty,
                        Ar = dto?.Ar ?? string.Empty
                    };

                entity.Name = MapLocalized(request.Name);
                entity.Description = MapLocalized(request.Description);
                entity.StartDate = request.StartDate;
                entity.EndDate = request.EndDate;
                entity.Location = MapLocalized(request.Location);
                entity.Latitude = request.Latitude;
                entity.Longitude = request.Longitude;
                entity.TicketPrice = request.TicketPrice != null ? MapLocalized(request.TicketPrice) : null;
                entity.IsFree = request.IsFree;
                entity.Category = MapLocalized(request.Category);
                entity.Organizer = request.Organizer != null ? MapLocalized(request.Organizer) : null;
                entity.ContactInfo = request.ContactInfo != null ? new EventContactInfo
                {
                    Phone = request.ContactInfo.Phone,
                    Email = request.ContactInfo.Email,
                    Website = request.ContactInfo.Website
                } : null;

                _unitOfWork.Events.Update(entity);
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
                    Message = "تم تحديث الفعالية بنجاح",
                    Code = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<TourismEventDto>
                {
                    Success = false,
                    Data = null!,
                    Message = $"حدث خطأ أثناء تعديل الفعالية: {ex.InnerException?.Message ?? ex.Message}",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}

