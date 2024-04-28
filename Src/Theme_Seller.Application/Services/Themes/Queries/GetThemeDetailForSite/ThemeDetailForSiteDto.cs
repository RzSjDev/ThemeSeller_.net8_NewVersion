namespace Theme_Seller.Application.Services.Themes.Queries.GetThemeDetailForSite
{
    public class ThemeDetailForSiteDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public List<string> Images { get; set; }
        public List<ThemeDetailForSite_FeaturesDto> Features { get; set; }
    }




}
