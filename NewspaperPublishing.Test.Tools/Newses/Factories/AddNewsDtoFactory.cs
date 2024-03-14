using NewspaperPublishing.Spec.Tests.Newses;

namespace NewspaperPublishing.Services.Unit.Tests.Newses
{
    public static class AddNewsDtoFactory
    {
        public static AddNewsDto Create(
            int? tagId1 = null,
            int? tagId2 = null)
        {
            return new AddNewsDto()
            {
                Title = "dummy-title ",
                Weight = 5,
                TagId = new List<int>
                {
                 tagId1?? 1,
                tagId2?? 2,
                }
            };
        }

    }
}
