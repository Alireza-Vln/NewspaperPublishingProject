using NewspaperPublishing.Contracts.Interfaces;
using NewspaperPublishing.Entities.Newses;
using NewspaperPublishing.Entities.NewspaperCategories;
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
        private List<NewspaperCategory> newsList;
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
            var weight = 0;
            foreach (var newsId in dto.newsId)
            {
               var news1= _newsRepository.FindNewsById(newsId);
                if (news1 == null)
                {
                    throw new Exception();
                }
                weight =weight+news1.Weight;
              
            }
            var newspaper = new Newspaper
            {
                Title = dto.Title,
                Date = _dateService.Now(),   
                Weight = weight,
               
            };
            
            _newspaperRepository.Add(newspaper);
            await _unitOfWork.Complete();
          

        }
    }
}
