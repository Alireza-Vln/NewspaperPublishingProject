using NewspaperPublishing.Contracts.Interfaces;
using NewspaperPublishing.Entities.Newses;
using NewspaperPublishing.Entities.NewspaperCategories;
using NewspaperPublishing.Entities.NewspaperNewses;
using NewspaperPublishing.Entities.Newspapers;
using NewspaperPublishing.Persistence.EF.Newspapers;
using NewspaperPublishing.Services.Newes.Contracts;
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
                var category=_categoryRepository.FindCategoryById(categoryId);
                var newspaperCategory = new NewspaperCategory()
                {
                    CategoryId = category.Id,
                };
              

                foreach (var newId in dto.newsId)
                {
                    var news=_newsRepository.FindNewsById(newId);
                    if(category.Id == news.CategoryId)
                    {
                        var newspaperNews = new NewspaperNews()
                        {
                            NewsId = news.Id,
                        };
                        newspaper.NewspaperNews.Add(newspaperNews);
                    }
                   
                }
                newspaper.NewspaperCategories.Add(newspaperCategory);
                
            }
            _newspaperRepository.Add(newspaper);
            await _unitOfWork.Complete();


        }
    }
}
