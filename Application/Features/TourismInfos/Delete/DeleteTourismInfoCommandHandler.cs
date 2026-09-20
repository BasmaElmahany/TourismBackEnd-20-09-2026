using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Application.Common.DTOs;
using Tourism.Application.IUnitofwork;

namespace Tourism.Application.Features.TourismInfos.Delete
{
    public class DeleteTourismInfoCommandHandler
        : IRequestHandler<DeleteTourismInfoCommand, ApiResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTourismInfoCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<bool>> Handle(
            DeleteTourismInfoCommand request,
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
                        Message = "المعلومات المراد حذفها غير موجودة",
                        Code = StatusCodes.Status404NotFound
                    };
                }

                _unitOfWork.TourismInfos.Delete(entity);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new ApiResponse<bool>
                {
                    Success = true,
                    Data = true,
                    Message = "تم حذف المعلومات بنجاح",
                    Code = StatusCodes.Status200OK
                };
            }
            catch
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "حدث خطأ أثناء الحذف",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}