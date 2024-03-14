using NewspaperPublishing.Contracts.Interfaces;
using NewspaperPublishing.Entities.Authors;
using NewspaperPublishing.Entities.Categories;
using NewspaperPublishing.Entities.Newses;
using NewspaperPublishing.Persistence.EF.Newspapers;
using NewspaperPublishing.Services.Authors.Contarcts.Dtos;
using NewspaperPublishing.Services.Newes.Contracts;
using NewspaperPublishing.Services.Newes.Contracts.Dtos;
using NewspaperPublishing.Services.Newes.Contracts.Exeptions;
using NewspaperPublishing.Services.Unit.Tests.Newses;
using NewspaperPublishing.Spec.Tests.Authors;
using NewspaperPublishing.Spec.Tests.Categories;
using NewspaperPublishing.Spec.Tests.Tags;
using System.Runtime.Serialization;

namespace NewspaperPublishing.Spec.Tests.Newses
{
    public class NewsAppService : NewsService
    {
        readonly NewsRepository _newsRepository;
        readonly UnitOfWork _unitOfWork;
        private CategoryRepository _categoryRepository;
        private AuthorRepository _authorRepository;
        private TagRepository _tagRepository;
        private NewspaperRepository _newspaperRepository;
        public NewsAppService(NewsRepository repository,
            UnitOfWork unitOfWork,
            CategoryRepository categoryRepository,
            AuthorRepository authorRepository,
            TagRepository tagRepository,
            NewspaperRepository newspaperRepository)
        {
            _newsRepository = repository;
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
            _authorRepository = authorRepository;
            _tagRepository = tagRepository;
            _newspaperRepository= newspaperRepository;

        }

        public async Task Add(int categoryId, int authorId, AddNewsDto dto)
        {
            var category= _categoryRepository.FindCategoryById(categoryId);
            if (category == null)
            {
                throw new ThrowAddNewsIfCategoryIsNullException();
            }
            var author=_authorRepository.FindAuthorById(authorId);
            if(author == null)
            {
                throw new ThrowAddNewsIfAuthorIsNullException();
            }  
            foreach (var i in dto.TagId)
            {
                var tag= _tagRepository.FindTagById(i);
             
                if(tag.CategoryId != category.Id)
                {
                    throw new ThrowAddNewsCategoriesDoNotMatchTagsException();
                }
            }
           
            var news = new News
            {
                Title = dto.Title,
                Weight = dto.Weight,
                CategoryId = category.Id,
                AuthorId=author.Id,
               
            };
            _newsRepository.Add(news);
            await _unitOfWork.Complete();
            
        }

        public async Task Delete(int id)
        {
            var news= _newsRepository.FindNewsById(id);
            if (news == null)
            {
                throw new ThrowDeleteNewsIfNewsIsException();
            }
            if(_newspaperRepository.FindNewspaperByNews
                (news.Id) != null)
            {
                throw new ThrowDeleteNewsThatHasBeenPublishedException();
            }
            _newsRepository.Delete(news);
            await _unitOfWork.Complete();
        }

        public async Task<List<GetNewsDto>> Get(FiltersNewsDto filter)
        {
            return _newsRepository.Get(filter);
        }

        public async Task Update(int id, UpdateNewsDto dto)
        {
            var news= _newsRepository.FindNewsById(id);
            if (news == null)
            {
                throw new ThrowUpdateNewsIfNewsIsNullException();
            }
            news.Title= dto.Title;
            news.Weight = dto.Weight;

            await _unitOfWork.Complete();
        }
    }
}
