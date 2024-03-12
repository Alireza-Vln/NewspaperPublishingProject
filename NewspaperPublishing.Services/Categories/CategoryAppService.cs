using NewspaperPublishing.Contracts.Interfaces;
using NewspaperPublishing.Entities.Categories;

namespace NewspaperPublishing.Spec.Tests.Categories
{
    public class CategoryAppService:CategoryService
    {
        readonly CategoryRepository _repository;
        readonly UnitOfWork _unitOfWork;
        public CategoryAppService(CategoryRepository repository,
            UnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(AddCategoryDto dto)
        {
            //if (_repository.Find(dto.Title) != null)
            //{

            //}
            var category = new Category
            {
                Title = dto.Title,
                Weight = dto.Weight,
            };
            _repository.Add(category);
            await _unitOfWork.Complete();
        }
    }
    
}
