namespace NewspaperPublishing.Services.Newes.Contracts.Dtos
{
    public class GetNewsDto
    {
        public int Id { get; set; }

        public string AuthorName { get; set; }
        public string Title { get; set; }
        public string CategoryTitle { get; set; }
        public List<string> Tags { get; set; }
        public int Weight { get; set; }
    }
}
