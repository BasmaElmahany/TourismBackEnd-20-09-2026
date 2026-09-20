using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Application.Common.DTOs;
using Tourism.Application.IUnitofwork;

namespace Tourism.Application.Features.Tourguide.Delete
{
    public class DeleteTourGuideCommandHandler
         : IRequestHandler<DeleteTourGuideCommand, ApiResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTourGuideCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<bool>> Handle(
            DeleteTourGuideCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _unitOfWork.TourGuides.GetByIdAsync(request.Id, cancellationToken);

                if (entity is null)
                {
                    return new ApiResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "المرشد السياحي المراد حذفه غير موجود",
                        Code = StatusCodes.Status404NotFound
                    };
                }

                _unitOfWork.TourGuides.Delete(entity);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new ApiResponse<bool>
                {
                    Success = true,
                    Data = true,
                    Message = "تم حذف المرشد السياحي بنجاح",
                    Code = StatusCodes.Status200OK
                };
            }
            catch
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "حدث خطأ أثناء حذف المرشد السياحي",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}