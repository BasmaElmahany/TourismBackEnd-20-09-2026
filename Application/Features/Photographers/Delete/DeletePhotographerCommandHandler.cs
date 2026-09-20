using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Application.Common.DTOs;
using Tourism.Application.IUnitofwork;

namespace Tourism.Application.Features.Photographers.Delete
{
    public class DeletePhotographerCommandHandler
           : IRequestHandler<DeletePhotographerCommand, ApiResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePhotographerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<bool>> Handle(
            DeletePhotographerCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _unitOfWork.Photographers.GetByIdAsync(request.Id, cancellationToken);

                if (entity is null)
                {
                    return new ApiResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "المصور المراد حذفه غير موجود",
                        Code = StatusCodes.Status404NotFound
                    };
                }

                _unitOfWork.Photographers.Delete(entity);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new ApiResponse<bool>
                {
                    Success = true,
                    Data = true,
                    Message = "تم حذف المصور بنجاح",
                    Code = StatusCodes.Status200OK
                };
            }
            catch
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "حدث خطأ أثناء حذف المصور",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}