using NewspaperPublishing.Entities.Categories;
using NewspaperPublishing.Services.Categories.Contracts.Dtos;

namespace NewspaperPublishing.Spec.Tests.Categories
{
    public interface CategoryRepository
    {
        void Add(Category category);
        Category? FindCategoryTitle(string Title);
        Category? FindCategoryById(int id);
        void Delete(Category? category);
        List<GetCategoryDto> GetAll();
        List<GetCategoryDto> GetCategoryMostNews();

    }
}
