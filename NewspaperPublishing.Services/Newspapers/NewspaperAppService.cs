using NewspaperPublishing.Contracts.Interfaces;
using NewspaperPublishing.Entities.Newses;
using NewspaperPublishing.Entities.NewspaperCategories;
using NewspaperPublishing.Entities.NewspaperNewses;
using NewspaperPublishing.Entities.Newspapers;
using NewspaperPublishing.Persistence.EF.Newspapers;
using NewspaperPublishing.Services.Newes.Contracts;
using NewspaperPublishing.Services.Newspapers.Contracts.Dtos;
using NewspaperPublishing.Services.Unit.Tests.Newspapers;
using NewspaperPublishing.Spec.Tests.Categories;

namespace NewspaperPublishing.Spec.Tests.Newspapers
{
    public class NewspaperAppService : NewspaperService
    {
        readonly NewspaperRepository _newspaperRepository;
        readonly UnitOfWork _unitOfWork;
        readonly DateTimeService _dateService;
        readonly NewsRepository _newsRepository;
        readonly CategoryRepository _categoryRepository;
        public NewspaperAppService(NewspaperRepository repository,
            UnitOfWork unitOfWork,
            DateTimeService dateService,
            NewsRepository newsRepository,
            CategoryRepository categoryRepository)
        {
            _newspaperRepository = repository;
            _unitOfWork = unitOfWork;
            _dateService = dateService;
            _newsRepository = newsRepository;
            _categoryRepository = categoryRepository;

        }

        public async Task Add(AddNewspaperDto dto)
        {

            var newspaper = new Newspaper
            {
                Title = dto.Title,
                Date = _dateService.Now(),
               

            };
            foreach (var categoryId in dto.CategoryId)
            {
                var weight = 0;
                var category=_categoryRepository.FindCategoryById(categoryId);
                if (category == null)
                {
                    throw new ThrowAddsNewspaperIfCategoryIsNullException();
                }
                var newspaperCategory = new NewspaperCategory()
                {
                    CategoryId = category.Id,
                };
               weight= category.Weight ;

                foreach (var newId in dto.newsId)
                {
                    var news=_newsRepository.FindNewsById(newId);
                    if (news == null)
                    {
                        throw new ThrowAddsNewspaperIfNewsIsNullException();
                    }
                    if(category.Id == news.CategoryId)
                    {
                        var newspaperNews = new NewspaperNews()
                        {
                            NewsId = news.Id,
                        };
                        newspaper.NewspaperNews.Add(newspaperNews);
                        weight = weight - news.Weight;
                    }
                }
                newspaper.NewspaperCategories.Add(newspaperCategory);
                if(weight!=0)
                {
                    throw new ThrowAddNewspaperTheWeightOfTheNewsCategoryHasNotReachedTheQuorumException();
                }
                
                newspaper.Weight=+category.Weight;
            }
            _newspaperRepository.Add(newspaper);
            await _unitOfWork.Complete();


        }

        public async Task<List<GetNewspaperDto>> Get()
        {
           return _newspaperRepository.Get();
        }
    }
}
