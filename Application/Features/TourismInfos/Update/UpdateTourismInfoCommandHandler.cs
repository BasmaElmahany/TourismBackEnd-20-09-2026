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

namespace Tourism.Application.Features.TourismInfos.Update
{
    public class UpdateTourismInfoCommandHandler
          : IRequestHandler<UpdateTourismInfoCommand, ApiResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTourismInfoCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<bool>> Handle(
            UpdateTourismInfoCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _unitOfWork.TourismInfos.GetByIdAsync(request.Id, cancellationToken);

                if (entity is null)
                {
                    return new ApiResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "المعلومات المراد تعديلها غير موجودة",
                        Code = StatusCodes.Status404NotFound
                    };
                }

                entity.Title = new LocalizedText { En = request.Title.En, Ar = request.Title.Ar };
                entity.Climate = new LocalizedText { En = request.Climate.En, Ar = request.Climate.Ar };
                entity.BestTimeToVisit = new LocalizedText { En = request.BestTimeToVisit.En, Ar = request.BestTimeToVisit.Ar };
                entity.WhatToWear = new LocalizedText { En = request.WhatToWear.En, Ar = request.WhatToWear.Ar };
                entity.Notes = request.Notes is null ? null : new LocalizedText { En = request.Notes.En, Ar = request.Notes.Ar };
                entity.LastUpdated = string.IsNullOrWhiteSpace(request.LastUpdated) ? DateTime.UtcNow.ToString("yyyy-MM-dd") : request.LastUpdated;

                _unitOfWork.TourismInfos.Update(entity);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new ApiResponse<bool>
                {
                    Success = true,
                    Data = true,
                    Message = "تم تعديل المعلومات بنجاح",
                    Code = StatusCodes.Status200OK
                };
            }
            catch
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "حدث خطأ أثناء التعديل",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}