using NewspaperPublishing.Test.Tools.Categories.Factories;

namespace NewspaperPublishing.Spec.Tests.Categories
{
    public interface CategoryService
    {
        Task Add(AddCategoryDto dto);
        Task Update(int id, UpdateCategoryDto dto);
    }
}
