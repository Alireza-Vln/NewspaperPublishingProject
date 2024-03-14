namespace NewspaperPublishing.Spec.Tests.Authors
{
    public static class UpdateAuthorDtoFactory
    {
        public static UpdateAuthorDto Create(
            string? firstName=null,
            string? lastName = null)
        {
            return new UpdateAuthorDto
            {
                FirstName = firstName??"update-first_name",
                LastName = lastName??"update-last-name"
            };
        }
    }
}
