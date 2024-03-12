using NewspaperPublishing.Entities.Categories;

namespace NewspaperPublishing.Spec.Tests.Categories
{
    public interface CategoryRepository
    {
        void Add(Category category);
        Category? Find(string Title);
    }
}
