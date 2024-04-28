using Microsoft.AspNetCore.Http;

namespace Theme_Seller.Application.Services.Themes.Commands.AddNewTheme
{
    public class RequestAddNewThemeDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public long CategoryId { get; set; }
        public bool Displayed { get; set; }

        public List<IFormFile> Images { get; set; }
        public List<AddNewTheme_Features> Features { get; set; }
    }
}
