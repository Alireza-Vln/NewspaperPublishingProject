using NewspaperPublishing.Services.Tags.Contracts.Dtos;

namespace NewspaperPublishing.Services.Unit.Tests.TagsTests
{
    public static class UpdateTagDtoFactory
    {
        public static UpdateTagDto Creat()
        {
            return new UpdateTagDto()
            {
                Title = "dummy-update-title"
            };
        }
    }
}
