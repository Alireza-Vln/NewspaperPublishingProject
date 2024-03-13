using NewspaperPublishing.Contracts.Interfaces;
using NewspaperPublishing.Entities.Tags;
using NewspaperPublishing.Services.Tags.Contracts.Dtos;
using NewspaperPublishing.Services.Tags.Contracts.Exceptions;
using NewspaperPublishing.Services.Unit.Tests.CategoryTests;
using NewspaperPublishing.Services.Unit.Tests.TagsTests;
using NewspaperPublishing.Spec.Tests.Categories;
using System.Runtime.Serialization;

namespace NewspaperPublishing.Spec.Tests.Tags
{
    public class TagAppService:TagService 
    {
        readonly TagRepository _repository;
        readonly UnitOfWork _unitOfWork;
       readonly CategoryRepository _categoryRepository;
        public TagAppService(TagRepository repository,UnitOfWork unitOfWork,CategoryRepository categoryRepository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
        }

        public async Task Add(int categoryId, AddTagDto dto)
        {
          var category= _categoryRepository.FindCategoryById(categoryId);
            if (category == null )
            {
                throw new ThrowAddTagIfCategoryIsNullException();
            }
            if (_repository.FindTagTitle(dto.Title) != null)
            {
                throw new ThrowAddTagIsDuplicateTitleException();
            }
            var tag = new Tag
            {
                Title = dto.Title,
                CategoryId = category.Id,
            };
            _repository.Add(tag);
            await _unitOfWork.Complete();

        }

        public async Task Delete(int id)
        {
            var tag = _repository.FindTagById(id);
            if (tag == null)
            {

            }
            _repository.Delete(tag);
            await _unitOfWork.Complete();

        }

        public async Task<List<GetTagDto>> Get()
        {
            return _repository.GetAll();
        }

        public async Task Update(int id, UpdateTagDto dto)
        {
            var tag = _repository.FindTagById(id);
            if (tag == null)
            {
                throw new ThrowUpdateTagIfTagIsNullException();
            }
            tag.Title= dto.Title;
          await  _unitOfWork.Complete();

        }
    }
}
