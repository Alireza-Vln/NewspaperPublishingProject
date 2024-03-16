using NewspaperPublishing.Entities.Newses;

namespace NewspaperPublishing.Services.Authors.Contarcts.Dtos
{
    public class GetAuthorsDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int View { get; set; }
       public int NewsCount { get; set; }
    }
}
