using NewspaperPublishing.Spec.Tests.Authors;

namespace NewspaperPublishing.Services.Unit.Tests.Authors
{
    public static class AddAuthorDtoFactory
    {
      public static AddAuthorDto Create()
        {
            return new AddAuthorDto()
            {
                FirstName = "dummy-first-name",
                LastName = "dummy-last-name",
            };
        }
    }
}
