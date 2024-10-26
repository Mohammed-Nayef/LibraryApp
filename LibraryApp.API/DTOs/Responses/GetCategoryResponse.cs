namespace LibraryApp.API.DTOs.Responses
{
    public class GetCategoryResponse
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; } = "";
        public List<GetSubcategoryResponse> Subcategories { get; set; } = [];
    }
}
