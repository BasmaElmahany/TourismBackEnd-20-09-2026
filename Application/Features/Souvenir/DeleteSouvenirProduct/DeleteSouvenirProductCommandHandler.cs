using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Application.Common.DTOs;
using Tourism.Application.IUnitofwork;

namespace Tourism.Application.Features.Souvenir.DeleteSouvenirProduct
{
    public class DeleteSouvenirProductCommandHandler
            : IRequestHandler<DeleteSouvenirProductCommand, ApiResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSouvenirProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<bool>> Handle(
            DeleteSouvenirProductCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _unitOfWork.SouvenirProducts.GetByIdAsync(request.Id, cancellationToken);

                if (entity is null)
                {
                    return new ApiResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "المنتج غير موجود",
                        Code = StatusCodes.Status404NotFound
                    };
                }

                _unitOfWork.SouvenirProducts.Delete(entity);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new ApiResponse<bool>
                {
                    Success = true,
                    Data = true,
                    Message = "تم حذف المنتج بنجاح",
                    Code = StatusCodes.Status200OK
                };
            }
            catch
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "حدث خطأ أثناء حذف المنتج",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}