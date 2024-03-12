using NewspaperPublishing.Entities.Categories;

namespace NewspaperPublishing.Spec.Tests.Categories
{
    public interface CategoryRepository
    {
        void Add(Category category);
        Category? FindCategoryTitle(string Title);
        Category? FindCategoryById(int id);
    }
}
