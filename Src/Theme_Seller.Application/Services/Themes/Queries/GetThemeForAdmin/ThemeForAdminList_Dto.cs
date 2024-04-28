namespace Theme_Seller.Application.Services.Themes.Queries.GetThemeForAdmin
{
    public class ThemeForAdminList_Dto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public bool Displayed { get; set; }
    }
}
