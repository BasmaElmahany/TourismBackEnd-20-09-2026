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

namespace Tourism.Application.Features.TourismInfos.GetById
{
    public class GetTourismInfoByIdQueryHandler
          : IRequestHandler<GetTourismInfoByIdQuery, ApiResponse<TourismInfoDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTourismInfoByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<TourismInfoDto>> Handle(
            GetTourismInfoByIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                var x = await _unitOfWork.TourismInfos.GetByIdAsync(request.Id, cancellationToken);

                if (x is null)
                {
                    return new ApiResponse<TourismInfoDto>
                    {
                        Success = false,
                        Data = null,
                        Message = "المعلومات المطلوبة غير موجودة",
                        Code = StatusCodes.Status404NotFound
                    };
                }

                var dto = new TourismInfoDto
                {
                    Id = x.Id,
                    Title = new LocalizedTextDto { En = x.Title.En, Ar = x.Title.Ar },
                    Climate = new LocalizedTextDto { En = x.Climate.En, Ar = x.Climate.Ar },
                    BestTimeToVisit = new LocalizedTextDto { En = x.BestTimeToVisit.En, Ar = x.BestTimeToVisit.Ar },
                    WhatToWear = new LocalizedTextDto { En = x.WhatToWear.En, Ar = x.WhatToWear.Ar },
                    Notes = x.Notes is null ? null : new LocalizedTextDto { En = x.Notes.En, Ar = x.Notes.Ar },
                    LastUpdated = x.LastUpdated
                };

                return new ApiResponse<TourismInfoDto>
                {
                    Success = true,
                    Data = dto,
                    Message = "تم جلب البيانات بنجاح",
                    Code = StatusCodes.Status200OK
                };
            }
            catch
            {
                return new ApiResponse<TourismInfoDto>
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