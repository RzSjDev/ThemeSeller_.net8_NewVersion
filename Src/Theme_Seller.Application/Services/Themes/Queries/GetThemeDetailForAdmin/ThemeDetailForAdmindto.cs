namespace Theme_Seller.Application.Services.Themes.Queries.GetProductDetailForAdmin
{
    public class ThemeDetailForAdmindto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public bool Displayed { get; set; }
        public List<ThemeDetailFeatureDto> Features { get; set; }
        public List<ThemeDetailImagesDto> Images { get; set; }
    }

}
