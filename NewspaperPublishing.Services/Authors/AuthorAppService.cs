﻿using NewspaperPublishing.Contracts.Interfaces;
using NewspaperPublishing.Entities.Authors;

namespace NewspaperPublishing.Spec.Tests.Authors
{
    public class  AuthorAppService : AuthorService
    {
        readonly AuthorRepository _repository;
        readonly UnitOfWork _unitOfWork;
        public AuthorAppService(AuthorRepository repository,
            UnitOfWork unitOfWork  )
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
    }
}
