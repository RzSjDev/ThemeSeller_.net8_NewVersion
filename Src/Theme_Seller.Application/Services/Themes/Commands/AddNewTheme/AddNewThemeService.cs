using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata;
using Theme_seller.Common;
using Theme_Seller.Application.Interfaces.Context;
using Theme_Seller.Domain.Entities.Themes;

namespace Theme_Seller.Application.Services.Themes.Commands.AddNewTheme
{
    public class AddNewThemeService : IAddNewThemeService
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;
        private readonly IMapper  _mapper;

        public AddNewThemeService(IMapper mapper,IDataBaseContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _environment = hostingEnvironment;
            _mapper = mapper;
        }


        public ResultDto Execute(RequestAddNewThemeDto request)
        {

            try
            {

                var category = _context.Categories.Find(request.CategoryId);
                var theme=_mapper.Map<Theme>(request);
                theme.CategoryThemes = category;
                _context.themes.Add(theme);

                List<ThemeImages> themeImages = new();
                foreach (var item in request.Images)
                {
                    var uploadedResult = UploadFile(item);
                    themeImages.Add(new ThemeImages
                    {
                        Theme = theme,
                        Src = uploadedResult.FileNameAddress,
                    });
                }

                _context.ThemeImages.AddRange(themeImages);


                List<ThemeFeatures> themeFeatures = new();
                foreach (var item in request.Features)
                {
                    themeFeatures.Add(new ThemeFeatures
                    {
                        Name = item.Name,
                        Value = item.Value,
                        Theme = theme,
                    });
                }
                _context.ThemeFeatures.AddRange(themeFeatures);

                _context.SaveChanges();

                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "محصول با موفقیت به محصولات فروشگاه اضافه شد",
                };
            }
            catch (Exception ex)
            {

                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "خطا رخ داد ",
                };
            }

        }


        private UploadDto UploadFile(IFormFile file)
        {
            if (file != null)
            {
                string folder = $@"images\ProductImages\";
                var uploadsRootFolder = Path.Combine(_environment.WebRootPath, folder);
                if (!Directory.Exists(uploadsRootFolder))
                {
                    Directory.CreateDirectory(uploadsRootFolder);
                }


                if (file == null || file.Length == 0)
                {
                    return new UploadDto()
                    {
                        Status = false,
                        FileNameAddress = "",
                    };
                }

                string fileName = DateTime.Now.Ticks.ToString() + file.FileName;
                var filePath = Path.Combine(uploadsRootFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                return new UploadDto()
                {
                    FileNameAddress = folder + fileName,
                    Status = true,
                };
            }
            return null;
        }
    }
}
