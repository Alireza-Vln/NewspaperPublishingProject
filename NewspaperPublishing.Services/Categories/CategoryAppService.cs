using NewspaperPublishing.Contracts.Interfaces;
using NewspaperPublishing.Entities.Categories;
using NewspaperPublishing.Services.Unit.Tests.CategoryTests;
using NewspaperPublishing.Test.Tools.Categories.Factories;

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
            if (_repository.FindCategoryTitle(dto.Title) != null)
            {
                throw new ThrowAddCategoryIsDuplicateTitleException();
            }
            var category = new Category
            {
                Title = dto.Title,
                Weight = dto.Weight,
            };
            _repository.Add(category);
            await _unitOfWork.Complete();
        }

        public async Task Delete(int id)
        {
            var category=_repository.FindCategoryById(id);
            if (category == null)
            {
                throw new ThrowDeletesCategoryIfCategoryIsNullException();
            }
            if(category.News==null)
            {
                throw new ThrowDeleteTheCategoryHasNewsException();
            }
            _repository.Delete(category);
            await _unitOfWork.Complete();
        }

        public async Task Update(int id, UpdateCategoryDto dto)
        {
            var category= _repository.FindCategoryById(id);
            if (category == null)
            {
                throw new ThrowUpdateCategoryIfCategoryIsNullException();


            }
            if(_repository.FindCategoryTitle(dto.Title) != null)
            {
                throw new ThrowUpdateCategoryIsDuplicateTitleException();
            }

            category.Title = dto.Title;
            category.Weight = dto.Weight;
            await _unitOfWork.Complete();
        }
    }
    
}
