namespace NewspaperPublishing.Spec.Tests.Tags
{
    public static class AddTagDtoFactory
    {
        public static AddTagDto Create(
        string? title=null
       )
        {
            return new AddTagDto()
            {
                Title = title ?? "dummy-title",
                
            };

        }
    }
}
