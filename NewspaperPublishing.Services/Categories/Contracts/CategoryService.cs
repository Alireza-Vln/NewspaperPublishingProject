using NewspaperPublishing.Services.Categories.Contracts.Dtos;
using NewspaperPublishing.Test.Tools.Categories.Factories;

namespace NewspaperPublishing.Spec.Tests.Categories
{
    public interface CategoryService
    {
        Task Add(AddCategoryDto dto);
        Task Delete(int id);
        Task<List<GetCategoryDto>> GetAll();
        Task<List<GetCategoryDto>> GetCategoryMostNews();
        Task Update(int id, UpdateCategoryDto dto);
    }
}
