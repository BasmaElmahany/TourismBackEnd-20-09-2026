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

namespace Tourism.Application.Features.Souvenir.GetAllSouvenirCategories
{
    public class GetAllSouvenirCategoriesQueryHandler
          : IRequestHandler<GetAllSouvenirCategoriesQuery, ApiResponse<List<SouvenirCategoryDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllSouvenirCategoriesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<List<SouvenirCategoryDto>>> Handle(
            GetAllSouvenirCategoriesQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                var categories = await _unitOfWork.SouvenirCategories.GetAllAsync(cancellationToken);

                var dtos = categories.Select(x => new SouvenirCategoryDto
                {
                    Key = x.Key,
                    Name = x.Name,
                    NameAr = x.NameAr,
                    Icon = x.Icon,
                    Description = x.Description,
                    DescriptionAr = x.DescriptionAr
                }).ToList();

                return new ApiResponse<List<SouvenirCategoryDto>>
                {
                    Success = true,
                    Data = dtos,
                    Message = "تم جلب تصنيفات الهدايا بنجاح",
                    Code = StatusCodes.Status200OK
                };
            }
            catch
            {
                return new ApiResponse<List<SouvenirCategoryDto>>
                {
                    Success = false,
                    Data = null,
                    Message = "حدث خطأ أثناء جلب التصنيفات",
                    Code = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}