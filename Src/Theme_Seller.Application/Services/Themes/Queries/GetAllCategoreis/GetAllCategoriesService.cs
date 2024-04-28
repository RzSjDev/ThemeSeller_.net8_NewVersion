using AutoMapper;
using Theme_seller.Common;
using Theme_Seller.Application.Interfaces.Context;

namespace Theme_Seller.Application.Services.Themes.Queries.GetAllCategoreis
{
    public class GetAllCategoriesService : IGetAllCategoriesService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;

        public GetAllCategoriesService(IMapper mapper,IDataBaseContext context)
        {
            _context = context;
            _mapper=mapper;
        }

        public ResultDto<List<AllCategoriesDto>> Execute()
        {
            var categories = _context.Categories.ToList().Select(p =>_mapper.Map<AllCategoriesDto>(p)).ToList();
            return new ResultDto<List<AllCategoriesDto>>
            {
                Data = categories,
                IsSuccess = false,
                Message = "",
            };
        }
    }
}
