namespace Theme_Seller.Application.Services.Themes.Queries.GetThemeForAdmin
{
    public class ThemeForAdminDto
    {
        public int RowCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }

        public List<ThemeForAdminList_Dto> themes { get; set; }
    }
}
