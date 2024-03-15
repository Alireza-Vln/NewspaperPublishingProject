using NewspaperPublishing.Contracts.Interfaces;
using NewspaperPublishing.Entities.Newspapers;
using NewspaperPublishing.Persistence.EF.Newspapers;
using NewspaperPublishing.Services.Newes.Contracts;

namespace NewspaperPublishing.Spec.Tests.Newspapers
{
    public class NewspaperAppService : NewspaperService
    {
        readonly NewspaperRepository _newspaperRepository;
        readonly UnitOfWork _unitOfWork;
        readonly DateTimeService _dateService;
        readonly NewsRepository _newsRepository;
        public NewspaperAppService(NewspaperRepository repository,
            UnitOfWork unitOfWork,
            DateTimeService dateService,
            NewsRepository newsRepository)
        {
            _newspaperRepository = repository;
            _unitOfWork = unitOfWork;
            _dateService = dateService;
            _newsRepository=newsRepository;

        }

        public async Task Add(AddNewspaperDto dto)
        {
            
            foreach (var newsId in dto.newsId)
            {
               var news= _newsRepository.FindNewsById(newsId);
                if (news == null)
                {

                }
                news.Category.Weight = -news.Weight;
                     
            }
            foreach(var newsId in dto.newsId)
            {
                var news = _newsRepository.FindNewsById(newsId);
                if(news.Category.Weight != 0)
                {

                }

            }

            var newspaper = new Newspaper
            {
                Title = dto.Title,
               
                Date = _dateService.Now(),   
            };
            _newspaperRepository.Add(newspaper);
            await _unitOfWork.Complete();
          

        }
    }
}
