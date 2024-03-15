using NewspaperPublishing.Contracts.Interfaces;
using NewspaperPublishing.Entities.Categories;
using NewspaperPublishing.Services.Categories.Contracts.Dtos;
using NewspaperPublishing.Services.Newes.Contracts;
using NewspaperPublishing.Services.Unit.Tests.CategoryTests;
using NewspaperPublishing.Test.Tools.Categories.Factories;

namespace NewspaperPublishing.Spec.Tests.Categories
{
    public class CategoryAppService:CategoryService
    {
        readonly CategoryRepository _repository;
        readonly UnitOfWork _unitOfWork;
        readonly NewsRepository _newsRepository;
        public CategoryAppService(CategoryRepository repository,
            UnitOfWork unitOfWork,
            NewsRepository newsRepository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _newsRepository = newsRepository;
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
            if(_newsRepository.FindNewsByCategory(category.Id)!=null)
            {
                throw new ThrowDeleteTheCategoryHasNewsException();
            }
            _repository.Delete(category);
            await _unitOfWork.Complete();
        }

        public async Task<List<GetCategoryDto>> GetAll()
        {
             return _repository.GetAll();
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
