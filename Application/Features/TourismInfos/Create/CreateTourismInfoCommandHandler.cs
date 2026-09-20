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
using Tourism.Domain.Entities.Common;
using Tourism.Domain.Entities;

namespace Tourism.Application.Features.TourismInfos.Create
{
    public class CreateTourismInfoCommandHandler
         : IRequestHandler<CreateTourismInfoCommand, ApiResponse<TourismInfoDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateTourismInfoCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<TourismInfoDto>> Handle(
            CreateTourismInfoCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                var entity = new TourismInfo
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = new LocalizedText { En = request.Title.En, Ar = request.Title.Ar },
                    Climate = new LocalizedText { En = request.Climate.En, Ar = request.Climate.Ar },
                    BestTimeToVisit = new LocalizedText { En = request.BestTimeToVisit.En, Ar = request.BestTimeToVisit.Ar },
                    WhatToWear = new LocalizedText { En = request.WhatToWear.En, Ar = request.WhatToWear.Ar },
                    Notes = request.Notes is null ? null : new LocalizedText { En = request.Notes.En, Ar = request.Notes.Ar },
                    LastUpdated = string.IsNullOrWhiteSpace(request.LastUpdated) ? DateTime.UtcNow.ToString("yyyy-MM-dd") : request.LastUpdated
                };

                await _unitOfWork.TourismInfos.AddAsync(entity, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                var dto = new TourismInfoDto
                {
                    Id = entity.Id,
                    Title = request.Title,
                    Climate = request.Climate,
                    BestTimeToVisit = request.BestTimeToVisit,
                    WhatToWear = request.WhatToWear,
                    Notes = request.Notes,
                    LastUpdated = entity.LastUpdated
                };

                return new ApiResponse<TourismInfoDto>
                {
                    Success = true,
                    Data = dto,
                    Message = "تم إضافة المعلومات السياحية بنجاح",
                    Code = StatusCodes.Status201Created
                };
            }
            catch
            {
                return new ApiResponse<TourismInfoDto>
                {
                    Success = false,
                    Data = null,
                    Message = "حدث خطأ أثناء الإضافة",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}