using NewspaperPublishing.Contracts.Interfaces;
using NewspaperPublishing.Entities.Authors;
using NewspaperPublishing.Services.Authors.Contarcts.Dtos;
using NewspaperPublishing.Services.Unit.Tests.Authors;

namespace NewspaperPublishing.Spec.Tests.Authors
{
    public class AuthorAppService : AuthorService
    {
        readonly AuthorRepository _repository;
        readonly UnitOfWork _unitOfWork;
        public AuthorAppService(AuthorRepository repository,
            UnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(AddAuthorDto dto)
        {
            var Author = new Author()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
            };
            _repository.Add(Author);
            await _unitOfWork.Complete();
        }

        public async Task Delete(int id)
        {
            var author = _repository.FindAuthorById(id);
            if (author == null)
            {
                throw new ThrowDeletesAuthorIfAuthorIsNullException();
            }
            _repository.Delete(author);
            await _unitOfWork.Complete();
        }

        public async Task<List<GetAuthorsDto>> Get()
        {
            
            return  _repository.GetAll();
        }

        public async Task<List<GetAuthorsDto>> GetAuthorMostNews()
        {
           return  _repository.GetAuthorMostNews();
        }

        public async Task Update(int id, UpdateAuthorDto dto)
        {
            var author = _repository.FindAuthorById(id);
            if (author == null)
            {
                throw new ThrowUpdatesAuthorIfAuthorIsNullException();
            }
            author.FirstName = dto.FirstName;
            author.LastName = dto.LastName;
            await _unitOfWork.Complete();
        }

       
    }
}
