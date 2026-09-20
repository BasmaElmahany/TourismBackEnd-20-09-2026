using MediatR;
using Microsoft.AspNetCore.Http;

using Tourism.Application.Common.DTOs;
using Tourism.Application.Features.Authentication.DTOs;
using Tourism.Application.IUnitofwork;

namespace Tourism.Application.Features.TourismInfos.GetAll
{
    public class GetAllTourismInfosQueryHandler
          : IRequestHandler<GetAllTourismInfosQuery, ApiResponse<List<TourismInfoDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllTourismInfosQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<List<TourismInfoDto>>> Handle(
            GetAllTourismInfosQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                var infos = await _unitOfWork.TourismInfos.GetAllAsync(cancellationToken);

                var dtos = infos.Select(x => new TourismInfoDto
                {
                    Id = x.Id,
                    Title = new LocalizedTextDto { En = x.Title.En, Ar = x.Title.Ar },
                    Climate = new LocalizedTextDto { En = x.Climate.En, Ar = x.Climate.Ar },
                    BestTimeToVisit = new LocalizedTextDto { En = x.BestTimeToVisit.En, Ar = x.BestTimeToVisit.Ar },
                    WhatToWear = new LocalizedTextDto { En = x.WhatToWear.En, Ar = x.WhatToWear.Ar },
                    Notes = x.Notes is null ? null : new LocalizedTextDto { En = x.Notes.En, Ar = x.Notes.Ar },
                    LastUpdated = x.LastUpdated
                }).ToList();

                return new ApiResponse<List<TourismInfoDto>>
                {
                    Success = true,
                    Data = dtos,
                    Message = "تم جلب المعلومات السياحية بنجاح",
                    Code = StatusCodes.Status200OK
                };
            }
            catch
            {
                return new ApiResponse<List<TourismInfoDto>>
                {
                    Success = false,
                    Data = null,
                    Message = "حدث خطأ أثناء جلب المعلومات السياحية",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}