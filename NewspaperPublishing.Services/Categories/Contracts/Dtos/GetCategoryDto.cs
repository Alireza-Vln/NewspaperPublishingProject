namespace NewspaperPublishing.Services.Categories.Contracts.Dtos
{
    public class GetCategoryDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Weight { get; set; }
        public int? View { get; set; }
        public int? NewspaperId { get; set; }
        public List<string> TagTitle { get; set; }

    }
}
